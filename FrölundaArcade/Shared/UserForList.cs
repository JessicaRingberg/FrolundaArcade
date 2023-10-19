namespace FrölundaArcade.Shared
{
    public class UserForList
    {
        public string Email { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public bool ShowCartDetails { get; set; }
        public bool ShowOrderDetails { get; set; }
    }
}
