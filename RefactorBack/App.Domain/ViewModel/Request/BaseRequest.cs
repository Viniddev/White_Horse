using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request;

public class BaseRequest
{
    [Required(ErrorMessage = "User id must valid")]
    public string UserId { get; set; } = string.Empty;
}
