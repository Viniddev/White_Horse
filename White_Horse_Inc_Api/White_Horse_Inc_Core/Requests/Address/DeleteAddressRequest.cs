using System.ComponentModel.DataAnnotations;

namespace White_Horse_Inc_Core.Requests.Roles
{
    public class DeleteAddressRequest
    {
        [Required(ErrorMessage = "Id Isn't a optional parameter.")]
        public int Id { get; set; }
    }
}
