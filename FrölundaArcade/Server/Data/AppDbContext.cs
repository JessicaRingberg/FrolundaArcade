using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;

namespace FrölundaArcade.Server.Data;
public class AppDbContext : ApiAuthorizationDbContext<AppUser>
{

    public AppDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Game>()
            .Property(e => e.ImageUrls)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

        builder.Entity<CartItem>()
            .HasKey(x => new { x.CartId, x.GameId });

        builder.Entity<OrderItem>()
           .HasKey(x => new { x.OrderId, x.GameId });
    }

}
