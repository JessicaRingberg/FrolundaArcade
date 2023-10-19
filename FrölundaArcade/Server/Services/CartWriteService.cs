using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class CartWriteService : ICartWriteService
    {
        private readonly AppDbContext _context;
        public CartWriteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(int gameId, string userId)
        {
            var cart = await _context.Carts
                .Include(x => x.Items).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync(x => x.AppUserId == userId);
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
            if (cart == null || game == null)
            {
                return;
            }

            var existingCartItem = cart.Items.FirstOrDefault(x => x.GameId == gameId);
            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity + 1 > existingCartItem.Game.Quantity)
                {
                    return;
                }

                existingCartItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { Quantity = 1, Game = game });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int gameId, string userId)
        {
            var cart = await _context.Carts.Include(x => x.Items).FirstOrDefaultAsync(x => x.AppUserId == userId);
            if (cart == null)
            {
                return;
            }

            var game = cart.Items.FirstOrDefault(g => g.GameId == gameId);
            if (game == null)
            {
                return;
            }
            if (game.Quantity > 1)
            {

                game.Quantity--;
            }
            else
            {
                cart.Items.Remove(game);
            }
            await _context.SaveChangesAsync();
        }
    }
}
