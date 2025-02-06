using White_Horse_Inc_Core.Models.Base;
using White_Horse_Inc_Core.Requests.Roles;

namespace White_Horse_Inc_Core.Models
{
    public class CompanyRole : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void Update(UpdateRolesRequest companyRole)
        {
            if (companyRole != null)
            {
                Name = companyRole.Name;
                Description = companyRole.Description;
            }
            else
            {
                throw new ArgumentNullException(nameof(companyRole));
            }
        }
    }
}
