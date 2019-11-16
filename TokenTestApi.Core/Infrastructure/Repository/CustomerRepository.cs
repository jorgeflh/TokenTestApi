﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TokenTestApi.Core.Domain.Interfaces.Repository;
using TokenTestApi.Core.Domain.Models;
using TokenTestApi.Core.Infrastructure.Data;

namespace TokenTestApi.Core.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IServiceScope scope;
        private readonly TokenTestApiContext tokenTestApiContext;

        public CustomerRepository(IServiceProvider services)
        {
            this.scope = services.CreateScope();
            this.tokenTestApiContext = this.scope.ServiceProvider.GetRequiredService<TokenTestApiContext>();
        }

        public async Task<bool> Create(Customer customer)
        {
            var success = false;

            tokenTestApiContext.Customer.Add(customer);

            var numberOfItemsCreated = await tokenTestApiContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public Customer GetById(int id)
        {
            var result = tokenTestApiContext.Customer
                                .Where(x => x.Id == id)
                                .FirstOrDefault();

            return result;
        }
    }
}
