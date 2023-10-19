using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FrölundaArcade.Server.Controllers;

[Authorize]
[Route("api/games/{gameId}/[controller]")]
public class ReviewsController : ApiControllerBase
{
    private readonly IReviewsWriteService _reviewsWriteService;

    public ReviewsController(IReviewsWriteService reviewsWriteService)
    {
        _reviewsWriteService = reviewsWriteService;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(int gameId, ReviewUpsert review)
    {
        await _reviewsWriteService.AddReview(gameId, HttpContext.User.FindFirst(ClaimTypes.Email).Value, review);

        return CreatedAtRoute(nameof(GamesController.GetGame), new { gameId }, gameId);
    }
    [Authorize(Policy = Constants.Admin)]
    [HttpDelete("{reviewId}")]
    public async Task DeleteReview(int reviewId)
    {
        await _reviewsWriteService.DeleteReview(reviewId);
    }
}
