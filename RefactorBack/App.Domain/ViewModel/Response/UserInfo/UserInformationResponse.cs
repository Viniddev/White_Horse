using App.Domain.Entities;
using App.Domain.Enums;

namespace App.Domain.ViewModel.Response.UserInfo;

public class UserInformationResponse
{
    public Guid Id { get; init; }
    public DateTime CreationDate { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Rg { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public UserAddress Address { get; set; } = null!;
    public string Role { get; set; } = string.Empty;

    public UserInformationResponse() { }

    public UserInformationResponse(UserInformations userInfo) 
    {
        Id = userInfo.Id;
        CreationDate = userInfo.CreationDate;
        Name = userInfo.Name;
        Cpf = userInfo.Cpf;
        Rg = userInfo.Rg;
        Email = userInfo.Email;
        PhoneNumber = userInfo.PhoneNumber;
        Role = userInfo.UserRole.ToString();
        Address = userInfo.UserAddress ?? new UserAddress();
    }
}
