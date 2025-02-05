using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Requests.Roles
{
    public class UpdateAddressRequest
    {
        [Required(ErrorMessage = "Id Isn't a optional parameter.")]
        public int Id { get; set; }

        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
