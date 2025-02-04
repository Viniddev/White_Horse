using System.ComponentModel.DataAnnotations;

namespace White_Horse_Inc_Core.Requests.Authentication
{
    public class Login
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
