using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Models
{
    public class CompanyRole : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
