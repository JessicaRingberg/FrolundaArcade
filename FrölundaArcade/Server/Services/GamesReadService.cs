using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class GamesReadService : IGamesReadService
    {

        private AppDbContext _context;

        public GamesReadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameForList>> GetAllAsync(GameFilters filters)
        {
            var games = await _context.Games.AsNoTracking()
                .ApplyFilters(filters)
                .OrderByDescending(g => g.Quantity)
                .MapToGameForList()
                .Take(filters.AmountOfItems)
                .ToListAsync();

            return games;
        }

        public async Task<GameDetails> GetGame(int gameId)
        {
            var game = await _context.Games.AsNoTracking()
                .Select(g => new GameDetails
                {
                    Id = g.Id,
                    Quantity = g.Quantity,
                    Name = g.Name,
                    Price = g.Price,
                    AgeLimit = g.AgeLimit,
                    Description = g.Description,
                    TechnicalSpec = g.TechnicalSpec,
                    Category = g.Category,
                    CategoryId = g.CategoryId,
                    CategoryName = g.Category.Name,
                    AverageReview = g.Reviews.Average(r => (double?)r.Rating),
                    Reviews = g.Reviews.Select(r => new ReviewDetails
                    {
                        Rating = r.Rating,
                        ReviewId = r.Id,
                        Text = r.Text
                    }).ToList(),
                    ImageUrl = g.ImageUrl,
                    ImageUrls = g.ImageUrls,
                })
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null) return game;

            game.RelatedGames = await _context.Games.AsNoTracking()
                .ApplyFilters(new GameFilters { AgeLimit = game.AgeLimit, Category = game.Category.Name })
                .Where(x => x.Id != gameId)
                .MapToGameForList()
                .OrderByDescending(x => x.AverageReview)
                .Take(3)
                .ToListAsync();

            return game;
        }

        public async Task<IEnumerable<GameForList>> GetProposals(string email)
        {
            var query = _context.Set<Order>().AsNoTracking().Where(x => x.CustomerEmail == email);

            var filters = new GameFilters
            {
                Category = await query.SelectMany(o => o.Items).Select(x => x.Game.Category.Name)
                                      .GroupBy(x => x).OrderByDescending(x => x.Count())
                                      .Select(x => x.Key).FirstOrDefaultAsync(),

                AgeLimit = query.SelectMany(o => o.Items).Max(x => x.Game.AgeLimit) ?? 18,
            };

            return await _context.Games.AsNoTracking()
                 .ApplyFilters(filters)
                 .MapToGameForList()
                 .Take(3)
                 .ToListAsync();
        }

        public async Task<IEnumerable<GameUpsert>> GetAllUpsertAsync()
        {
            var games = await _context.Games
                .Select(g => new GameUpsert
                {
                    Name = g.Name,
                    AgeLimit = g.AgeLimit,
                    CategoryId = g.CategoryId,
                    Description = g.Description,
                    Id = g.Id,
                    ImageUrl = g.ImageUrl,
                    Price = g.Price
                }).ToListAsync();

            return games;
        }
    }
}
