namespace FrölundaArcade.Shared
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public IEnumerable<GameForOrder>? Games { get; set; }
        public string CustomerEmail { get; set; }
        public OrderStatus.Status OrderStatus { get; set; }
        public AddressDetails ShippingAddress { get; set; }
    }
}