namespace FrölundaArcade.Server.Entities;

public class OrderItem
{
    public int OrderId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}