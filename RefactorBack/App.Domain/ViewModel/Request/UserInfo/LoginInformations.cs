using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.UserInfo;

public class LoginInformations
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
