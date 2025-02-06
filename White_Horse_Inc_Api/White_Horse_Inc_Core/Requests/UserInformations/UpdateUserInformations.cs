using System.ComponentModel.DataAnnotations;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Core.Requests.UserInformations
{
    public class UpdateUserInformations
    {
        [Required(ErrorMessage = "Id Isn't a optional parameter.")]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int CompanyRoleId { get; set; }
        public int AddressId { get; set; }
    }
}
