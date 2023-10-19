namespace FrölundaArcade.Server.Entities;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int? AgeLimit { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string TechnicalSpec { get; set; }
    public string ImageUrl { get; set; }
    public List<string> ImageUrls { get; set; } = new();

    public Category Category { get; set; }
    public int CategoryId { get; set; }

    public ICollection<Review>? Reviews { get; set; }
}
