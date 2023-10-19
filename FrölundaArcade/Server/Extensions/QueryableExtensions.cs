using System.Linq.Expressions;

namespace FrölundaArcade.Server.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> FilterWhen<T>(this IQueryable<T> source, Expression<Func<T, bool>> filter, bool whenTrue)
    {
        if (!whenTrue) return source;

        return source.Where(filter);
    }
}