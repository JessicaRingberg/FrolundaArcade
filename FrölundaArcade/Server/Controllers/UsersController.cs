using FrölundaArcade.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FrölundaArcade.Server.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUsersReadService _userReadService;
        private readonly IUsersWriteService _usersWriteService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        public UsersController(IUsersReadService userReadService, IUsersWriteService usersWriteService,
            SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _userReadService = userReadService;
            _usersWriteService = usersWriteService;
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpGet]
        public async Task<IEnumerable<UserForList>> GetUsers()
        {
            var users = await _userReadService.GetAllAsync();
            return users;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<UserDetails> GetUser(string userId)
        {
            var user = await _userReadService.GetUser(userId);
            return user;
        }

        [Authorize]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(UserDetails userId)
        {
            await _usersWriteService.UpdateAsync(userId);
            return NoContent();
        }
        [Route("[Action]")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
                string returnUrl = Url.Content("~/");
                var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, userLogin.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return NoContent();
                }
        }

        [HttpGet("{email}/[Action]")]
        public async Task<IEnumerable<GameForList>> Proposals(string email, [FromServices] IGamesReadService gamesService)
        {
            var games = await gamesService.GetProposals(email);

            return games;
        }

        [Route("[Action]")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            string returnUrl = Url.Content("~/");
            var user = CreateUser(userRegister);
            await _userStore.SetUserNameAsync(user, userRegister.UserName, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
            else
            {
                return NoContent();
            }
        }
        private AppUser CreateUser(UserRegister userRegister)
        {
            return new AppUser
            {
                Address = new Address
                {
                    City = userRegister.Address.City,
                    Zipcode = userRegister.Address.Zipcode,
                    Street = userRegister.Address.Street,
                },
                PhoneNumber = userRegister.PhoneNumber,
                Email = userRegister.Email
            };
        }
    }
}
