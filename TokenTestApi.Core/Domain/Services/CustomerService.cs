using System;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Interfaces.Service;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ITokenService tokenService;

        public CustomerService(ICustomerRepository customerRepository, ITokenService tokenService)
        {
            this.customerRepository = customerRepository;
            this.tokenService = tokenService;
        }

        public async Task<CustomerToken> Create(Customer customer)
        {
            customer.RegistrationDateTimeInUtc = DateTime.UtcNow;

            var success = await customerRepository.Create(customer);

            if (success)
            {
                var token = await tokenService.Create(customer);

                CustomerToken customerToken = new CustomerToken
                {
                    RegistrationDate = customer.RegistrationDateTimeInUtc,
                    Token = token.Value
                };

                return customerToken;
            }

            return null;
        }
    }
}
