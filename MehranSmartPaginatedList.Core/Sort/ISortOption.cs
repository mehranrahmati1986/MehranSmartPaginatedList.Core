namespace MehranSmartPaginatedList.Core.Sort;

public interface ISortOption
{
    string PropertyName { get; }
    bool Descending { get; }
    int Priority { get; }
}


