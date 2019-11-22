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
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            if (customer.CardNumber.ToString().Length != 16)
                return BadRequest("Card number lenght error");

            if (customer.Cvv.ToString().Length > 5)
                return BadRequest("Cvv lenght error");

            var result = await customerService.Create(customer);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("validatetoken")]
        public async Task<IActionResult> ValidateToken([FromBody]ValidateToken validateToken)
        {
            if (validateToken.Cvv.ToString().Length > 5)
                return BadRequest("Cvv lenght error");

            var result = await tokenService.ValidateToken(validateToken);
            return Ok(result);
        }
    }
}