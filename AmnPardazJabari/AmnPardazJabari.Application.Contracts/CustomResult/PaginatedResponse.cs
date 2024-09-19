namespace AmnPardazJabari.Application.Contracts.CustomResult;

public sealed record PaginatedResponse<TDto>(List<TDto> Items, int PageNumber, int PageSize, int ItemCount, Dictionary<string, object>? AdditionalValues = null)
{
    public int TotalPages => (int)Math.Ceiling(ItemCount / (double)PageSize);

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
}