using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Response.Dtos
{
    public class UserInformationResponse
    {
        public long Id { get; init; }
        public DateTime CreationDate { get; init; }

        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public RoleResponse Role { get; set; } = null!;
        public AddressResponse AddressResponse { get; set; } = null!;

    }
}
