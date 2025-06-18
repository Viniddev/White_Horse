namespace App.Domain.ViewModel.Response.UserInfo;

public class LoginResponse(string token, string userName, string email)
{
    public string Token { get; set; } = token;
    public string UserName { get; set; } = userName;
    public string Email { get; set; } = email;
}
