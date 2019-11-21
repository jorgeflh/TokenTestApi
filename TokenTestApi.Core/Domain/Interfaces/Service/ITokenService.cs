using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Interfaces.Service
{
    public interface ITokenService
    {
        Task<Token> Create(Customer customer);
    }
}
