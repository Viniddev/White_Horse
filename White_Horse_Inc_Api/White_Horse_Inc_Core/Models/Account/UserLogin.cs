using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Models.Account
{
    public class UserLogin
    {
        public string Email { get; set; } = string.Empty;
        public required string Password { get; set; }
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
