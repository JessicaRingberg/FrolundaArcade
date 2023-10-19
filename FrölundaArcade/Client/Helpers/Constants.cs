using FrölundaArcade.Shared;

namespace FrölundaArcade.Client.Helpers
{
    public static class Constants
    {
        public const string Games = "/api/games/";

        public const string Users = "/api/users/";

        public const string Categories = "/api/categories/";

        public const string Cart = "/api/cart/";
        public const string CookiesPopup = "showPopup";
      
        public const string UserIdClaim = "sub";
        public const string EmailClaim = "email";

        public const string Orders = "/api/orders/";
        public const string Tillbehör = "Tillbehör";
      
        public static string GameDetails(int gameId)
        {
            return Games + gameId;
        }
        public static string Reviews(int gameId)
        {
            return GameDetails(gameId) + "/reviews/";
        }

        public static string GameUpsert()
        {
            return Games + "GetAllUpsert/";
        }
        public static string Login()
        {
            return Users + "Login/";
        }
        public static string Register()
        {
            return Users + "Register/";
        }
        public static string GuestOrder()
        {
            return Orders + "CreateGuestOrder/";
        }
        public static string GetAllOrders()
        {
            return Orders + "GetAllOrdersAdmin/";
        }
    }
}
