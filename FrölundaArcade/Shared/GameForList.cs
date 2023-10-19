using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared
{
    public class GameForList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int? AgeLimit { get; set; }

        public string Category { get; set; }

        public string ImageURL { get; set; }
        [Range(1, 5)]
        public double? AverageReview { get; set; }
    }
}