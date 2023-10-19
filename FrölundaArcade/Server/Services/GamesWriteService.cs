using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class GamesWriteService : IGamesWriteService
    {
        private AppDbContext _context;

        public GamesWriteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(GameUpsert game)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == game.CategoryId);
            if (category is null)
            {
                return default;
            }

            var newGame = MapToGame(new Game(), game);

            await _context.AddAsync(newGame);
            await _context.SaveChangesAsync();

            return newGame.Id;
        }

        public async Task DeleteAsync(int id)
        {

            var game = await _context.Games
                .Include(g => g.Category)
                .Include(g => g.Reviews)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
            {
                return;
            }

            _context.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameUpsert game)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == game.CategoryId);
            if (category is null)
            {
                return;
            }

            var gameToUpdate = await _context.Games
                .Include(g => g.Category)
                .FirstOrDefaultAsync(g => g.Id == game.Id);

            if (gameToUpdate is null)
            {
                return;
            }

            MapToGame(gameToUpdate, game);
            await _context.SaveChangesAsync();
        }

        private Game MapToGame(Game toGame, GameUpsert fromGame)
        {
            toGame.Name = fromGame.Name;
            toGame.AgeLimit = fromGame.AgeLimit;
            toGame.Price = fromGame.Price;
            toGame.CategoryId = fromGame.CategoryId;
            toGame.ImageUrl = fromGame.ImageUrl;
            toGame.Description = fromGame.Description;
            toGame.TechnicalSpec = fromGame.TechnicalSpec;
            toGame.Quantity = fromGame.Quantity;

            return toGame;
        }
    }
}
