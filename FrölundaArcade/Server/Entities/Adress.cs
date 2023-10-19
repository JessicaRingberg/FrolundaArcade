using Microsoft.EntityFrameworkCore;

namespace FrölundaArcade.Server.Entities
{
    [Owned]
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string Zipcode { get; set; }
    }
}
