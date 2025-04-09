using MehranSmartPaginatedList.Core.Paginations;
using MehranSmartPaginatedList.Core.Sort;
using Microsoft.EntityFrameworkCore;

namespace MehranSmartPaginatedList.Core.Extensions;

public static class PaginationExtensions
{
    // تبدیل به لیست صفحه‌بندی‌شده به صورت همزمان
    public static PaginatedList<T> ToPaginatedList<T>(
        this IQueryable<T> source,
        int pageIndex,
        int pageSize,
        IEnumerable<ISortOption>? sortOptions = null)
    {
        int totalCount = source.Count();

        // مرتب‌سازی گزینه‌ها بر اساس اولویت
        List<ISortOption>? sortedOptions = sortOptions?.OrderBy(x => x.Priority).ToList();

        // اعمال مرتب‌سازی در صورت وجود
        if (sortOptions != null && sortOptions.Any())
        {
            source = source.ApplySorting(sortOptions);
        }

        List<T> items = [.. source
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)];

        // ایجاد و برگرداندن لیست صفحه‌بندی‌شده
        return new PaginatedList<T>(items, totalCount, pageIndex, pageSize,
            string.Join(", ", sortOptions?.Select(x => $"{x.PropertyName} {(x.Descending ? "desc" : "asc")}") ?? []));

    }

    // تبدیل به لیست صفحه‌بندی‌شده به صورت غیرهمزمان
    public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> source,
        int pageIndex,
        int pageSize,
        IEnumerable<ISortOption>? sortOptions = null,
        CancellationToken cancellationToken = default)
    {
        int totalCount = await source.CountAsync(cancellationToken);

        // اعمال مرتب‌سازی در صورت وجود
        if (sortOptions != null && sortOptions.Any())
        {
            source = source.ApplySorting(sortOptions);
        }

        List<T> items = await source
                              .Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync(cancellationToken);

        // ایجاد و برگرداندن لیست صفحه‌بندی‌شده
        return new PaginatedList<T>(items, totalCount, pageIndex, pageSize,
            string.Join(", ", sortOptions?.Select(x => $"{x.PropertyName} {(x.Descending ? "desc" : "asc")}") ?? []));
        ;
    }
}
