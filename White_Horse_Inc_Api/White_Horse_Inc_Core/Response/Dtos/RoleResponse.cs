using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Response.Dtos
{
    public class RoleResponse
    {
        public long Id { get; init; }
        public DateTime CreationDate { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
