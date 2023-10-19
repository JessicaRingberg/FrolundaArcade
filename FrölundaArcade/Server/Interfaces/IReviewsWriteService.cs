namespace FrölundaArcade.Server.Interfaces;

public interface IReviewsWriteService
{
    Task AddReview(int gameId, string email, ReviewUpsert review);
    Task DeleteReview(int reviewId);
}
