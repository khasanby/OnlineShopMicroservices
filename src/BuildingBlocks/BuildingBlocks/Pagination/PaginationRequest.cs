namespace BuildingBlocks.Pagination;

/// <summary>
/// Represents a request for paginated data.
/// </summary>
/// <param name="PageNumber"></param>
/// <param name="PageSize"></param>
public record PaginationRequest(int PageNumber = 0, int PageSize = 10);
