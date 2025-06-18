
namespace App.Domain.ViewModel.Request;

public class PagedRequest : BaseRequest
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}
