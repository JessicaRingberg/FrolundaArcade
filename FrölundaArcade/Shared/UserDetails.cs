using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared
{
    public class UserDetails
    {
        public string AppUserId { get; set; }
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public IEnumerable<CartGame> Cart { get; set; }
        public AddressDetails Address { get; set; }
        public ICollection<OrderDetails> Orders { get; set; }
        public bool ShowCartDetails { get; set; }
        public bool ShowOrderDetails { get; set; }
    }
}
