using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class OrdersReadService : IOrdersReadService
    {
        private readonly AppDbContext _context;
        public OrdersReadService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetails>> GetOrders(string email)
        {
            var orders = await _context.Set<Order>().AsNoTracking().Where(o => o.CustomerEmail == email).Select(o => new OrderDetails
            {
                Id = o.Id,
                Games = o.Items.Select(g => new GameForOrder
                {
                    Price = g.Game.Price,
                    Name = g.Game.Name,
                    ImageURL = g.Game.ImageUrl,
                    GameId = g.GameId,
                    Quantity = g.Quantity,
                }),
                CustomerEmail = o.CustomerEmail,
                ShippingAddress = new AddressDetails
				{
                    City = o.ShippingAddress.City,
                    Street = o.ShippingAddress.Street,
                    Zipcode = o.ShippingAddress.Zipcode
				},
                OrderStatus = o.OrderStatus,
            }).ToListAsync();

            return orders;
        }
        public async Task<IEnumerable<OrderDetails>> GetAllOrders()
        {
            var orders = await _context.Set<Order>().AsNoTracking().OrderBy(x => x.OrderStatus).Select(o => new OrderDetails
            {
                Id = o.Id,
                Games = o.Items.Select(g => new GameForOrder
                {
                    Price = g.Game.Price,
                    Name = g.Game.Name,
                    ImageURL = g.Game.ImageUrl,
                    GameId = g.GameId,
                    Quantity = g.Quantity,
                }),
                CustomerEmail = o.CustomerEmail,
                ShippingAddress = new AddressDetails
                {
                    City = o.ShippingAddress.City,
                    Street = o.ShippingAddress.Street,
                    Zipcode = o.ShippingAddress.Zipcode
                },
                OrderStatus = o.OrderStatus,
            }).ToListAsync();

            return orders;
        }
    }
}
