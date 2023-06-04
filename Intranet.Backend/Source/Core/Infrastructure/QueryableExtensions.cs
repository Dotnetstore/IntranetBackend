using System.Linq.Expressions;

namespace Core.Infrastructure;

public static class QueryableExtensions
{
    public static IQueryable<TSource> WhereNullable<TSource, TParameter>(this IQueryable<TSource> source,
        TParameter parameter, Expression<Func<TSource, bool>> predicate)
    {
        return parameter is null ? source : source.Where(predicate);
    }
}