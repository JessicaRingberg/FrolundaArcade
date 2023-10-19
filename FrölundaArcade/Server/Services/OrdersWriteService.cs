using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class OrdersWriteService : IOrdersWriteService
    {
        private readonly AppDbContext _context;

        public OrdersWriteService(AppDbContext context)
        {
            _context = context;
        }

		public async Task CreateGuestOrder(List<CartGame> games, GuestInfo guestInfo)
		{
            var order = new Order
            {
                Items = games.Select(x =>
                {
                    var orderItem = new OrderItem
                    {
                        GameId = x.GameId,
                        Game = _context.Games.FirstOrDefault(g => g.Id == x.GameId),
                        Price = x.Price,
                        Quantity = x.Quantity,
                    };

                    orderItem.Game.Quantity -= orderItem.Quantity;

                    return orderItem;
                }).ToArray(),
                OrderStatus = OrderStatus.Status.Behandlas,
                CustomerEmail = guestInfo.Email,
                ShippingAddress = new Address
                {
                    City = guestInfo.Address.City,
                    Street = guestInfo.Address.Street,
                    Zipcode = guestInfo.Address.Zipcode
                },
            };
            await _context.Set<Order>().AddAsync(order);
            await _context.SaveChangesAsync();
        }

		public async Task CreateOrder(string userId)
        {
            var user = await _context.Users
                .Include(x => x.Orders).Include(x => x.Cart).ThenInclude(x => x.Items).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync(x => x.Id == userId);

            foreach (var item in user.Cart.Items)
            {
                if (item.Quantity > item.Game.Quantity)
                {
                    throw new InvalidOperationException($"Can't purchase {item.Quantity} when there is {item.Game.Quantity} in stock");
                }
            }

            var order = new Order
            {
                Items = user.Cart.Items.Select(x =>
                {
                    var orderItem = new OrderItem
                    {
                        Game = x.Game,
                        GameId = x.GameId,
                        Price = x.Game.Price,
                        Quantity = x.Quantity,
                    };

                    x.Game.Quantity -= orderItem.Quantity;

                    return orderItem;
                }).ToArray(),
                OrderStatus = OrderStatus.Status.Behandlas,
                CustomerEmail = user.Email,
                ShippingAddress = new Address
                {
                    City = user.Address.City,
                    Street = user.Address.Street,
                    Zipcode = user.Address.Zipcode
                },
            };

            user.Orders.Add(order);
            user.Cart = new Cart();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(OrderDetails order)
        {
            var updatedOrder = await _context.Set<Order>().FirstOrDefaultAsync(o => o.Id == order.Id);
            if (updatedOrder == null)
            {
                return;
            }
            
            updatedOrder.OrderStatus = order.OrderStatus;
            await _context.SaveChangesAsync();
        }
    }
}
