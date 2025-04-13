using MehranSmartPaginatedList.Core.Sort;
using System.Linq.Expressions;

namespace MehranSmartPaginatedList.Core.Extensions;

public static class SortingExtensions
{
    public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> source,
        IEnumerable<ISortOption> sortOptions)
    {
        bool first = true;

        foreach (var sortOption in sortOptions.OrderBy(x => x.Priority))
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, sortOption.PropertyName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName;

            if (first)
            {
                // برای اولین بار از OrderBy یا OrderByDescending استفاده می‌کنیم
                methodName = sortOption.Descending ? "OrderByDescending" : "OrderBy";
                first = false;  // از این به بعد از ThenBy یا ThenByDescending استفاده می‌کنیم
            }
            else
            {
                // برای مرتب‌سازی بعدی از ThenBy یا ThenByDescending استفاده می‌کنیم
                methodName = sortOption.Descending ? "ThenByDescending" : "ThenBy";
            }

            // نتیجه query مرتب شده را با استفاده از Expression.Call اعمال می‌کنیم
            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                [typeof(T), property.Type],
                source.Expression,
                Expression.Quote(lambda));

            source = source.Provider.CreateQuery<T>(resultExpression);
        }

        return source;
    }
}


