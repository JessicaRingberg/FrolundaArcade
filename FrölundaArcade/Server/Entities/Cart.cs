namespace FrölundaArcade.Server.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}
