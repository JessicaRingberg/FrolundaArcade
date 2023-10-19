namespace FrölundaArcade.Server.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public Address ShippingAddress { get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public OrderStatus.Status OrderStatus { get; set; }
    }
}
