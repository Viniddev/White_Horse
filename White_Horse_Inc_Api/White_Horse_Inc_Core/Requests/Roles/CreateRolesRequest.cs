using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Requests.Roles
{
    public class CreateRolesRequest
    {
        [Required(ErrorMessage = "Name Isn't a optional parameter")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description Isn't a optional parameter")]
        public string Description { get; set; } = string.Empty;
    }
}
