using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.ViewModel.Request.Address;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.UserInfo;

public class RegisterInformation
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Cpf { get; set; } = string.Empty;
    [Required] 
    public string Rg { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;
    [Required] 
    public string PhoneNumber { get; set; } = string.Empty;
    [Required] 
    public EUserRoles UserRole { get; set; } = EUserRoles.User;
    [Required]
    public CreateAddressRequest UserAddress { get; set; } = null!;
   
}
