using App.Domain.Entities;
using App.Domain.Enums;

using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.UserInfo;

public class UpdateUserInformations
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required] 
    public string PhoneNumber { get; set; } = string.Empty;
    [Required] 
    public EUserRoles UserRole { get; set; } = EUserRoles.User;
    [Required]
    public UserAddress Address { get; set; } = null!;
   
}
