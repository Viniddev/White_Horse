using White_Horse_Inc_Core.Models.Base;
using White_Horse_Inc_Core.Requests.UserInformations;

namespace White_Horse_Inc_Core.Models
{
    public class UserInformations : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


        public long CompanyRoleId { get; set; }
        public virtual CompanyRole CompanyRole { get; set; } = null!;


        public long AddressId { get; set; }
        public virtual UserAddress Address { get; set; } = null!;


        public void Update(UpdateUserInformations userInformations)
        {
            if (userInformations != null)
            {
                Name = userInformations.Name;
                Cpf = userInformations.Cpf;
                Rg = userInformations.Rg;
                Email = userInformations.Email;
                Password = userInformations.Password;
                PhoneNumber = userInformations.PhoneNumber;
                CompanyRoleId = userInformations.CompanyRoleId;
                AddressId = userInformations.AddressId;
            }
            else
            {
                throw new ArgumentNullException(nameof(userInformations));
            }
        }
    }
}
