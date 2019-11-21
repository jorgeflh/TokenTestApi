using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Interfaces.Service
{
    public interface ICustomerService
    {
        Task<CustomerToken> Create(Customer customer);
    }
}