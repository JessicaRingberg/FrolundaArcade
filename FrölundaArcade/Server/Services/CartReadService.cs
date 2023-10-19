using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class CartReadService : ICartReadService
    {
        private readonly AppDbContext _context;
        public CartReadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartGame>> GetProductsAsync(string userId)
        {
            var cart = await _context.Carts.AsNoTracking()
                .Include(x => x.Items).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync(x => x.AppUserId == userId);

          return cart.Items.Select(g => new CartGame
            {
                Price = g.Game.Price,
                Name = g.Game.Name,
                GameId = g.Game.Id,
                ImageURL = g.Game.ImageUrl,
                Quantity = g.Quantity,
                StockQuantity = g.Game.Quantity
            }).ToArray();
        }
    }
}
