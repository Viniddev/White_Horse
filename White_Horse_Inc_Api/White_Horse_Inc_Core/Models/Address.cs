

using White_Horse_Inc_Core.Models.Account;

namespace White_Horse_Inc_Core.Models
{
    public class Address : BaseEntity
    {
        public string CEP { get; set; } = string.Empty;

        public User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
