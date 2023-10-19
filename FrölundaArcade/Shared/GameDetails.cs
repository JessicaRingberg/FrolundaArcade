using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared
{
    public class GameDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(50, 699)]
        public double Price { get; set; }

        [Range(3, 18)]
        public int? AgeLimit { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string TechnicalSpec { get; set; }

        [Range(1, 5)]
        public double? AverageReview { get; set; }   

        public IEnumerable<ReviewDetails>? Reviews { get; set; }

        public string ImageUrl { get; set; }

        public List<string> ImageUrls { get; set; } = new();

        public List<GameForList> RelatedGames { get; set; } = new();
    }
}
