using FrölundaArcade.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FrölundaArcade.Server.Controllers
{
    public class CartController : ApiControllerBase
    {
        private readonly ICartWriteService _cartWriteService;
        private readonly ICartReadService _cartReadService;

        public CartController(ICartWriteService cartWriteService, ICartReadService cartReadService)
        {
            _cartWriteService = cartWriteService;
            _cartReadService = cartReadService;
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<IActionResult> AddProduct(int id)
        {
            // GET userId
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _cartWriteService.AddProductAsync(id, userId);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteProduct(int gameId)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _cartWriteService.DeleteProductAsync(gameId, userId);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CartGame>> GetProducts()
		{
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var games = await _cartReadService.GetProductsAsync(userId);
            return games;
        }

        
        [Authorize(Policy = Constants.Admin)]
        [HttpGet("{id}")]
        public async Task<IEnumerable<CartGame>> GetProductsAdmin(string Id)
        {
            var games = await _cartReadService.GetProductsAsync(Id);
            return games;
        }
    }
}
