using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Response.Dtos
{
    public class AddressResponse
    {
        public long Id { get; init; }
        public DateTime CreationDate { get; init; }
        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
