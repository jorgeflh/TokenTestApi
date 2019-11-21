using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Interfaces.Repository
{
    public interface ITokenRepository
    {
        Task<Token> Create(Token token);
    }
}
