using System;
using System.Collections.Generic;
using System.Text;

namespace TokenTestApi.Core.Domain.Models
{
    public class ValidateToken
    {
        public DateTime RegistrationDate { get; set; }
        public string Token { get; set; }
        public int Cvv { get; set; }
    }
}
