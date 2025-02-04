using White_Horse_Inc_Core.Models.Base;
using White_Horse_Inc_Core.Requests.Authentication;

namespace White_Horse_Inc_Core.Models
{
    public class Address : BaseEntity
    {
        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Number { get; set; }

        public UserInformations User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
