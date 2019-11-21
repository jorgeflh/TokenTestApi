using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenTestApi.Core.Domain.Interfaces.Service;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public TokenController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        [HttpPost("create")]
        public async Task<CustomerToken> Create([FromBody]Customer customer)
        {
            var result = await customerService.Create(customer);

            return result;
        }
    }
}