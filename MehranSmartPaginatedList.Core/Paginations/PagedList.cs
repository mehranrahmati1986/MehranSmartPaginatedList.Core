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
    public bool HasNextPage => PageIndex < TotalPages;
    //public int TotalPages => (int)Math.Ceiling(totalCount / (double)pageSize);
    public int TotalPages => (totalCount + pageSize - 1) / pageSize;
}
