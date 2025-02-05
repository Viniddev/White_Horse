using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Requests.Roles
{
    public class DeleteRoleRequest
    {
        [Required(ErrorMessage = "Id Isn't a optional parameter.")]
        public int Id { get; set; }
    }
}
