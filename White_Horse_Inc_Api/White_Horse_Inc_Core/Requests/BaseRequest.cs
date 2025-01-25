using System.ComponentModel.DataAnnotations;

namespace White_Horse_Inc_Core.Requests
{
    public class BaseRequest
    {
        [Required(ErrorMessage = "User id must valid")]
        public string UserId { get; set; } = string.Empty;
    }
}
