using System;

namespace TokenTestApi.Core.Domain.Models
{
    public class CustomerToken
    {
        public DateTime RegistrationDate { get; set; }
        public string Token { get; set; }
    }
}
