using System.Threading.Tasks;
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
        private readonly ITokenService tokenService;

        public TokenController(ICustomerService customerService, ITokenService tokenService)
        {
            this.customerService = customerService;
            this.tokenService = tokenService;
        }
        
        [HttpPost("create")]
        public async Task<CustomerToken> Create([FromBody]Customer customer)
        {
            var result = await customerService.Create(customer);
            return result;
        }

        [HttpPost("validatetoken")]
        public async Task<bool> ValidateToken([FromBody]ValidateToken validateToken)
        {
            var result = await tokenService.ValidateToken(validateToken);
            return result;
        }
    }
}