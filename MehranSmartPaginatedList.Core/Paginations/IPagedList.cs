namespace MehranSmartPaginatedList.Core.Paginations;

public interface IPagedList
{
    /// <summary>
    /// جمع کل صفحه ها
    /// </summary>
    int TotalPages { get; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    int PageIndex { get; }

    /// <summary>
    /// تعداد رکوردهای قابل نمایش در هر صفحه
    /// </summary>
    int PageSize { get; }

    /// <summary>
    /// تعداد کل رکورد ها
    /// </summary>
    int TotalCount { get; }

    /// <summary>
    /// Sort expression
    /// </summary>
    string SortExpression { get; }

    /// <summary>
    /// امکان دکمه قبل
    /// </summary>
    bool HasPreviousPage { get; }

    /// <summary>
    /// امکان دکمه بعد
    /// </summary>
    bool HasNextPage { get; }
}
