using White_Horse_Inc_Api.Mappings;
using White_Horse_Inc_Core.Interfaces;

namespace White_Horse_Inc_Api.Implementation
{
    public class CompanyRoleRepository : IBaseRepository<CompanyRoleMapping>
    {
        public Task CreateAsync(CompanyRoleMapping model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CompanyRoleMapping model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyRoleMapping>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyRoleMapping> GetAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyRoleMapping model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
