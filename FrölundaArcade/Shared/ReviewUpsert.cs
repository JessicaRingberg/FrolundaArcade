using System.ComponentModel.DataAnnotations;

namespace FrölundaArcade.Shared;
public class ReviewUpsert
{
    public int? ReviewId { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }
    public string Text { get; set; }
}
