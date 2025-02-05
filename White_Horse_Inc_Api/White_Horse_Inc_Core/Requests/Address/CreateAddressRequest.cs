using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Requests.Roles
{
    public class CreateAddressRequest
    {
        [Required(ErrorMessage = "Cep Isn't a optional parameter")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Street Isn't a optional parameter")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Neighborhood Isn't a optional parameter")]
        public string Neighborhood { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description Isn't a optional parameter")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description Isn't a optional parameter")]
        public int Number { get; set; }
    }
}