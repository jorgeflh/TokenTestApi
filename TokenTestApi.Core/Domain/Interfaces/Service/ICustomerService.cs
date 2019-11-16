using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(int id);
        Task<Customer> Create(Customer customer);
    }
}