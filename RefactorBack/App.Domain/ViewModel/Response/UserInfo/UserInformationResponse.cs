using App.Domain.Entities;

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
    public Guid UserAddressId { get; set; }

    public static UserInformationResponse Map(UserInformations userInfo) 
    {
        return new() 
        {
            Id = userInfo.Id,
            CreationDate = userInfo.CreationDate,
            Name = userInfo.Name,
            Cpf = userInfo.Cpf,
            Rg = userInfo.Rg,
            Email = userInfo.Email,
            PhoneNumber = userInfo.PhoneNumber,
            UserAddressId = userInfo.UserAddressId
        };
    }
}
