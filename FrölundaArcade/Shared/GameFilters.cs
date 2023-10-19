using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared
{
    public class GameFilters
    {
        public string? Name { get; set; }
        public string? Category { get; set; }

        public bool OnlyInStock { get; set; } = true;

        [Range(3, 18)] public int? AgeLimit { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; } = Double.MaxValue;
        public int AmountOfItems { get; set; } = 50;
    }
}