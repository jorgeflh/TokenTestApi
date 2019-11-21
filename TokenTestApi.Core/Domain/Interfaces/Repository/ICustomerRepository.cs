using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> Create(Customer customer);
    }
}