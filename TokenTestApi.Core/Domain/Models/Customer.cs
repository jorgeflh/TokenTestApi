using System;
using System.Collections.Generic;
using System.Text;

namespace TokenTestApi.Core.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public ulong CardNumber { get; set; }
        public int Cvv { get; set; }
        public DateTime RegistrationDateTimeInUtc { get; set; }
        public virtual Token Token { get; set; }
    }
}
