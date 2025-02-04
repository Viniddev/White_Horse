using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Implementations.Repositories
{
    public class CompanyRoleRepository(AppDbContext context, ILogger<BaseRepository<CompanyRole>> logger) : BaseRepository<CompanyRole>(context, logger), ICompanyRoleRepository
    {
    }
}
