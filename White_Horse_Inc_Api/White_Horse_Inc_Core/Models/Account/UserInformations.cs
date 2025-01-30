using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Models.Account
{
    public class UserInformations: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


        public long CompanyRoleId { get; set; }
        public CompanyRole CompanyRole { get; set; } = null!;


        public long AddressId { get; set; }
        public Address Address { get; set; } = null!;

    }
}
