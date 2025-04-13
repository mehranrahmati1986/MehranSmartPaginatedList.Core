using MehranSmartPaginatedList.Core.Extensions;
using MehranSmartPaginatedList.Core.Models;
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

public class PaginatedList<T>(PaginationModel<T> model) : IPaginatedList<T>
{
    public List<T> Items { get; set; } = model.Items;
    public IPagedList PaginationInfo { get; private set; } 
        = new PagedList(
            model.TotalCount,
            model.PageIndex,
            model.PageSize,
            model.SortExpressionSummary);

    public async Task<PaginatedList<T>> CreateAsync(
    IQueryable<T> source,
    int pageIndex,
    int pageSize,
    IEnumerable<ISortOption> sortOptions,
    CancellationToken cancellationToken = default)
    {
        // لیست دیتا ها
        List<T> items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        // جمع کل
        int totalCount = await source.CountAsync(cancellationToken);

        // اعمال سورت‌ها طبق اولویت
        source = source.ApplySorting(sortOptions);

        // مرتب سازی
        string sortExpressionSummary = string.Join(", ",
            sortOptions.Select(x => $"{x.PropertyName} {(x.Descending ? "desc" : "asc")}"));

        var model = new PaginationModel<T>(items, totalCount, pageIndex, pageSize, sortExpressionSummary);

        return new PaginatedList<T>(model);
    }
}




