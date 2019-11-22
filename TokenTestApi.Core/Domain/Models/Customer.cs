using Newtonsoft.Json;
using System;

namespace TokenTestApi.Core.Domain.Models
{
    public class Customer
    {
        [JsonIgnore]
        public int Id { get; set; }

        public ulong CardNumber { get; set; }
        public int Cvv { get; set; }

        [JsonIgnore]
        public DateTime RegistrationDateTimeInUtc { get; set; }

        [JsonIgnore]
        public  Token Token { get; set; }
    }
}
