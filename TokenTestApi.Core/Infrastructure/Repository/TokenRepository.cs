using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Models;
using TokenTestApi.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TokenTestApi.Core.Infrastructure.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IServiceScope scope;
        private readonly TokenTestApiContext tokenTestApiContext;

        public TokenRepository(IServiceProvider services)
        {
            this.scope = services.CreateScope();
            this.tokenTestApiContext = this.scope.ServiceProvider.GetRequiredService<TokenTestApiContext>();
        }

        public async Task<Token> Create(Token token)
        {
            tokenTestApiContext.Token.Add(token);

            var numberOfItemsCreated = await tokenTestApiContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                return token;

            return null;
        }
    }
}
