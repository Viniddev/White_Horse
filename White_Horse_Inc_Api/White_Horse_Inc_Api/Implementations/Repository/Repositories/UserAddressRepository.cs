using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Implementations.Repository.Repositories
{
    public class UserAddressRepository(AppDbContext context, ILogger<BaseRepository<UserAddress>> logger) : BaseRepository<UserAddress>(context, logger), IUserAddressRepository
    {
    }
}
