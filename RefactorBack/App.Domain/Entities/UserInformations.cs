using App.Domain.Abstractions;
using App.Domain.ViewModel.Request.UserInfo;
using App.Domain.Enums;

namespace App.Domain.Entities;

public class UserInformations: BaseEntity, IAggregateRoot
{
    //default constructor for EF Core
    public string Name { get; private set; } = string.Empty;
    public string Cpf { get; private set; } = string.Empty;
    public string Rg { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;

    public EUserRoles UserRole { get; private set; } = EUserRoles.User;

    public Guid UserAddressId { get; private set; }
    public virtual UserAddress UserAddress { get; private set; } = null!;

    public UserInformations() { }

    public void CopyValuesFrom(UpdateUserInformations userInformations)
    {
        Email = userInformations.Email;
        PhoneNumber = userInformations.PhoneNumber;
        UserRole = userInformations.UserRole;
        UserAddress = userInformations.Address;
    }

    public UserInformations(RegisterInformation userInformations, Guid AddressId)
    {
        Name = userInformations.Name;
        Cpf = userInformations.Cpf;
        Rg = userInformations.Rg;
        Email = userInformations.Email;
        PhoneNumber = userInformations.PhoneNumber;
        UserRole = userInformations.UserRole;
        UserAddressId = AddressId;
    }
}
