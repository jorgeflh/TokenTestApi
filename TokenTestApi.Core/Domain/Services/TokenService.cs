using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Interfaces.Service;
using TokenTestApi.Core.Domain.Models;
using TokenTestApi.Core.Domain.Helpers;

namespace TokenTestApi.Core.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository tokenRepository;
        private readonly ICustomerRepository customerRepository;

        public TokenService(ITokenRepository tokenRepository, ICustomerRepository customerRepository)
        {
            this.tokenRepository = tokenRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<Token> Create(Customer customer)
        {
            try
            {
                var tokenString = customer.CardNumber + DateTime.UtcNow.ToString("yyyyMMddHHmm");
                var tokenArrayInt = tokenString.Select(c => int.Parse(c.ToString())).ToArray();
                var rawToken = ArrayHelpers.GetFromAbsoluteDiff(tokenArrayInt);
                rawToken = ArrayHelpers.RightRotate(rawToken, customer.Cvv);

                tokenString = "";
                foreach (var item in rawToken)
                {
                    tokenString += item;
                }

                Token token = new Token
                {
                    CustomerId = customer.Id,
                    Value = tokenString
                };

                var newToken = await tokenRepository.Create(token);

                if (newToken != null)
                    return newToken;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ValidateToken(ValidateToken validateToken)
        {
            var customer = await customerRepository.GetCustomerByRegistrationDate(validateToken.RegistrationDate);

            TimeSpan ts = DateTime.UtcNow - customer.RegistrationDateTimeInUtc;
            if (ts.TotalMinutes > 15)
                return false;

            return true;
        }
    }
}
