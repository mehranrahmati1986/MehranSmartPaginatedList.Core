using MehranSmartPaginatedList.Core.Sort;

namespace MehranSmartPaginatedList.Core.Models;

public class PaginationInput
{
    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int PageIndex { get; init; }

    /// <summary>
    /// اندازه صفحه
    /// </summary>
    public int PageSize { get; init; }

    /// <summary>
    /// مرتب‌ سازی
    /// </summary>
    public IEnumerable<SortOption> SortOptions { get; init; }
}