using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services;
public class ReviewsWriteService : IReviewsWriteService
{
    private readonly AppDbContext _context;
    public ReviewsWriteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddReview(int gameId, string email, ReviewUpsert review)
    {
        var order = await _context.Set<Order>()
            .Include(x => x.Items)
            .ThenInclude(x => x.Game)
            .ThenInclude(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.CustomerEmail == email && x.Items.Any(x => x.GameId == gameId));

        if (order is null)
        {
            return;
        }

        var game = order.Items.First(x => x.GameId == gameId).Game;
        game.Reviews.Add(new Review { Rating = review.Rating, Text = review.Text });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReview(int reviewId)
    {
        var game = await _context.Set<Review>().FirstOrDefaultAsync(x => x.Id == reviewId);
        _context.Set<Review>().Remove(game);
        await _context.SaveChangesAsync();
    }
}
