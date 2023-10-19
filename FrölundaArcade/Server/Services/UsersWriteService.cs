using FrölundaArcade.Server.Data;

namespace FrölundaArcade.Server.Services
{
    public class UsersWriteService : IUsersWriteService
    {
        private readonly AppDbContext _context;
        public UsersWriteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task UpdateAsync(UserDetails userDetails)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userDetails.AppUserId);
            if (user is null)
            {
                return;
            }

            user.Address.City = userDetails.Address.City;
            user.Address.Zipcode = userDetails.Address.Zipcode;
            user.Address.Street = userDetails.Address.Street;
            user.PhoneNumber = userDetails.PhoneNumber;
            user.Email = userDetails.Email;
            user.UserName = userDetails.Email;
            await _context.SaveChangesAsync();
        }
    }
}
