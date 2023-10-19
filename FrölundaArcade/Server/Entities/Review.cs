using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Server.Entities
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Text { get; set; }
        public int GameId { get; set; }
    }
}
