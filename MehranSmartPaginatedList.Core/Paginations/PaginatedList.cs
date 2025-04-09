using MehranSmartPaginatedList.Core.Extensions;
using MehranSmartPaginatedList.Core.Sort;
using Microsoft.EntityFrameworkCore;

namespace MehranSmartPaginatedList.Core.Paginations;

public interface IPaginatedList<T>
{
    List<T> Items { get; set; }
    IPagedList PaginationInfo { get; }

    /// <summary>
    /// ایجاد لیست صفحه‌بندی‌شده از منبع IQueryable همراه با مرتب‌سازی دلخواه
    /// </summary>
    Task<PaginatedList<T>> CreateAsync(
        IQueryable<T> source,
        int pageIndex,
        int pageSize,
        IEnumerable<ISortOption> sortOptions,
        CancellationToken cancellationToken = default);
}

public class PaginatedList<T>(
    List<T> items,
    int totalCount,
    int pageIndex,
    int pageSize,
    string sortExpressionSummary) : IPaginatedList<T>
{
    public List<T> Items { get; set; } = items;
    public IPagedList PaginationInfo { get; private set; } 
        = new PagedList(totalCount, pageIndex, pageSize, sortExpressionSummary);

    public async Task<PaginatedList<T>> CreateAsync(
    IQueryable<T> source,
    int pageIndex,
    int pageSize,
    IEnumerable<ISortOption> sortOptions,
    CancellationToken cancellationToken = default)
    {
        int totalCount = await source.CountAsync(cancellationToken);

        // اعمال سورت‌ها طبق اولویت
        source = source.ApplySorting(sortOptions);

        List<T> items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        string sortExpressionSummary = string.Join(", ",
            sortOptions.Select(x => $"{x.PropertyName} {(x.Descending ? "desc" : "asc")}"));

        return new PaginatedList<T>(items, totalCount, pageIndex, pageSize, sortExpressionSummary);
    }
}




