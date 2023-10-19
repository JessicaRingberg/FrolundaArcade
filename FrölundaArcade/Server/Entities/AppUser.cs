using Microsoft.AspNetCore.Identity;

namespace FrölundaArcade.Server.Entities;
public class AppUser : IdentityUser
{
    public Cart Cart { get; set; } = new Cart();

    public Address Address { get; set; } = new Address();

    public ICollection<Order> Orders { get; set; }
}
