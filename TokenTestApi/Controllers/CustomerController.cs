using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenTestApi.Core.Domain.Interfaces.Services;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            var result = await customerService.Create(customer);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}