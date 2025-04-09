namespace MehranSmartPaginatedList.Core.Paginations;

public class PagedList(
    int totalCount,
    int pageIndex,
    int pageSize,
    string sortExpression) : IPagedList
{
    public int PageIndex => pageIndex;
    public int PageSize => pageSize;
    public int TotalCount => totalCount;
    public string SortExpression => sortExpression;
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < totalCount;
    public int TotalPages => (int)Math.Ceiling(totalCount / (double)pageSize);
}
