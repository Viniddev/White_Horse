namespace App.Domain.ViewModel.Response.UserInfo;

public class LoginResponse(string token, string userName, string email)
{
    public string Token { get; private set; } = token;
    public string UserName { get; private set; } = userName;
    public string Email { get; private set; } = email;
}
