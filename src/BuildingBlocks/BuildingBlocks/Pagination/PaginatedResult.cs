namespace BuildingBlocks.Pagination;

public class PaginatedResult<TEntity>
    (int pageNumber, int pageSize, long totalCount, IEnumerable<TEntity> items)
    where TEntity : class
{
    /// <summary>
    /// The current page number.
    /// </summary>
    public int PageNumber { get; } = pageNumber;
    /// <summary>
    /// The size of the page.
    /// </summary>
    public int PageSize { get; } = pageSize;
    /// <summary>
    /// The total number of items.
    /// </summary>
    public long TotalCount { get; } = totalCount;
    /// <summary>
    /// The items on the current page.
    /// </summary>
    public IEnumerable<TEntity> Items { get; } = items;
}