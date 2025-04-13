using MehranSmartPaginatedList.Core.Sort;

namespace MehranSmartPaginatedList.Core.Models;

/// <summary>
/// مدل ورودی صفحه بندی به همراه مرتب سازی
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginationModel<T>(
    List<T> items,
    int totalCount,
    int pageIndex,
    int pageSize,
    string sortExpressionSummary)
{
    /// <summary>
    /// لیستی از دیتا ها
    /// </summary>
    public List<T> Items { get; init; } = items;

    /// <summary>
    /// جمع کل
    /// </summary>
    public int TotalCount { get; init; } = totalCount;

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int PageIndex { get; init; } = pageIndex;

    /// <summary>
    /// اندازه صفحه
    /// </summary>
    public int PageSize { get; init; } = pageSize;

    /// <summary>
    /// مرتب‌ سازی
    /// </summary>
    public string SortExpressionSummary { get; init; } = sortExpressionSummary;

    /// <summary>
    /// مرتب‌ سازی
    /// </summary>
    public IEnumerable<SortOption> SortOptions { get; init; }
}