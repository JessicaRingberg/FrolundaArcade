using Duende.IdentityServer.Models;
using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class UsersReadService : IUsersReadService
    {
        private readonly AppDbContext _context;
        public UsersReadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDetails> GetUser(string userId)
        {
            return await _context.Users.Select(u => new UserDetails
            {
                AppUserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = new AddressDetails
                {
                    City = u.Address.City,
                    Street = u.Address.Street,
                    Zipcode = u.Address.Zipcode
                },
                Cart = u.Cart.Items.Select(g => new CartGame
                {
                    Price = g.Game.Price,
                    Name = g.Game.Name,
                    ImageURL = g.Game.ImageUrl,
                    GameId = g.GameId,
                    Quantity = g.Quantity,
                    StockQuantity = g.Game.Quantity
                }).ToList(),
                Orders = u.Orders.Select(o => new OrderDetails
                {
                    Id = o.Id,
                    Games = o.Items.Select(g => new GameForOrder
                    {
                        Price = g.Game.Price,
                        Name = g.Game.Name,
                        ImageURL = g.Game.ImageUrl,
                        GameId = g.GameId,
                        Quantity = g.Quantity,
                    }).ToList(),
                    CustomerEmail = o.CustomerEmail,
                    OrderStatus = o.OrderStatus
                }).ToList()
            }).FirstOrDefaultAsync(u => u.AppUserId == userId);
        }

        public async Task<IEnumerable<UserForList>> GetAllAsync()
        {
            return await _context.Users.Select(u => new UserForList
            {
                AppUserId = u.Id,
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
            }).ToListAsync();
        }
    }
}
