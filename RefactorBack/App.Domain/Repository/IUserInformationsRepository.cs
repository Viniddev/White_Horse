using App.Domain.Entities;
using App.Domain.Repository.Base;
using App.Domain.ViewModel.Response.UserInfo;

namespace App.Domain.Repository;

public interface IUserInformationsRepository : IRepositoryBase<UserInformations>
{
    Task<UserInformations?> GetUserProfileInformationsRepository(GetProfileInfo email, CancellationToken cancellationToken = default);
}
