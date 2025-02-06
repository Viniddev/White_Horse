using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Implementations.Repository.Repositories
{
    public class UserInformationsRepository(AppDbContext context, ILogger<BaseRepository<UserInformations>> logger) : BaseRepository<UserInformations>(context, logger), IUserInformationsRepository
    {
    }
}
