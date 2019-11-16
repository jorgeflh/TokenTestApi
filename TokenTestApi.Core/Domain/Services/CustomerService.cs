using System;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Interfaces.Services;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Create(Customer customer)
        {
            customer.RegistrationDateTimeInUtc = DateTime.UtcNow;

            var success = await customerRepository.Create(customer);

            if (success)
                return customer;
            else
                return null;
        }

        public Customer Get(int id)
        {
            var result =  customerRepository.GetById(id);

            return result;
        }

    }
}
