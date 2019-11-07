using System;
using System.Collections.Generic;
using System.Text;

namespace TokenTestApi.Core.Domain.Models
{
    public class Customer
    {
        public DateTime RegistrationDate { get; set; }
        public long CardNumber { get; set; }
        public int Cvv { get; set; }
        public long Token { get; set; }
    }
}
