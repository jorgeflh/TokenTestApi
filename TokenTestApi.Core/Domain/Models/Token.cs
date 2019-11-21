namespace TokenTestApi.Core.Domain.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
    }
}
