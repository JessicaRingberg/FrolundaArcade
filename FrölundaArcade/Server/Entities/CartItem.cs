namespace FrölundaArcade.Server.Entities;

public class CartItem
{
    public int CartId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public int Quantity { get; set; }
}
