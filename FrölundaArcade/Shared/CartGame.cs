namespace FrölundaArcade.Shared
{
    public class CartGame
	{
		public int GameId { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
    }
}
