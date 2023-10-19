using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared
{
    public class GameUpsert
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(50, 699)]
        public double Price { get; set; }

        [Range(3, 18)] public int? AgeLimit { get; set; } = 18;

        [Required]
        public int CategoryId { get; set; }
        
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string TechnicalSpec { get; set; }
    }
}
