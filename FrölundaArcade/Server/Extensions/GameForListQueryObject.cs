namespace FrölundaArcade.Server.Extensions;

public static class GameForListQueryObject
{
    public static IQueryable<GameForList> MapToGameForList(this IQueryable<Game> source)
    {
        return source.Select(g => new GameForList
        {
            AgeLimit = g.AgeLimit,
            Price = g.Price,
            Category = g.Category.Name,
            Name = g.Name,
            Id = g.Id,
            ImageURL = g.ImageUrl,
            Quantity = g.Quantity,
            AverageReview = g.Reviews.Average(r => (double?)r.Rating)
        });
    }

    public static IQueryable<Game> ApplyFilters(this IQueryable<Game> source, GameFilters filters)
    {
        return source.FilterWhen(g => g.Name.Contains(filters.Name), !string.IsNullOrWhiteSpace(filters.Name))
                .FilterWhen(g => g.Category.Name.Contains(filters.Category), !string.IsNullOrWhiteSpace(filters.Category))
                .FilterWhen(g => g.AgeLimit <= filters.AgeLimit || !g.AgeLimit.HasValue, filters.AgeLimit.HasValue)
                .Where(g => g.Price >= filters.MinPrice && g.Price <= filters.MaxPrice)
                .FilterWhen(g => g.Quantity > 0, filters.OnlyInStock);
    }
}
