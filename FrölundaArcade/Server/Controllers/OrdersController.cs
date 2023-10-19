using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FrölundaArcade.Server.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrdersReadService _ordersReadService;
        private readonly IOrdersWriteService _ordersWriteService;
        public OrdersController(IOrdersWriteService ordersWriteService, IOrdersReadService ordersReadService)
        {
            _ordersReadService = ordersReadService;
            _ordersWriteService = ordersWriteService;
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpGet("{email}")]
        public async Task<IEnumerable<OrderDetails>> GetOrdersAdmin(string email)
        {
            var orders = await _ordersReadService.GetOrders(email);
            return orders;
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpGet, Route("[Action]")]
        public async Task<IEnumerable<OrderDetails>> GetAllOrdersAdmin()
        {
            var orders = await _ordersReadService.GetAllOrders();
            return orders;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<OrderDetails>> GetOrders()
        {
            var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return await _ordersReadService.GetOrders(email);
        }

        [Authorize]
        [HttpPost]
        public async Task CreateOrder()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _ordersWriteService.CreateOrder(userId);
        }

        [HttpPost, Route("[Action]")]
        public async Task CreateGuestOrder(GuestOrder guestOrder)
        { 
            await _ordersWriteService.CreateGuestOrder(guestOrder.Games, guestOrder.Register);
        }

        [Authorize]
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(OrderDetails orderId)
        {
            await _ordersWriteService.UpdateOrder(orderId);
            return NoContent();
        }
    }
}
