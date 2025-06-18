using System.Text.Json.Serialization;

namespace App.Domain.ViewModel.Response;

public class PagedResponse<TData> : BaseResponse<TData>
{
    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount, int pageSize, int currentPage = 1) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null) : base(data, code, message)
    {
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
}
