using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.ViewModel.Response.UserInfo;
using App.Infrastructure.Data;
using App.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository;

public class UserInformationsRepository(AppDbContext _Dbcontext) :
    RepositoryBase<UserInformations>(_Dbcontext), 
    IUserInformationsRepository
{
    private readonly DbSet<UserInformations> _context = _Dbcontext.Set<UserInformations>();

    public async Task<UserInformations?> GetUserProfileInformationsRepository(GetProfileInfo email, CancellationToken cancellationToken = default)
    {
        try 
        {
            var response = await _context.FirstOrDefaultAsync(x => x.Email.Equals(email.Email) && x.IsActive, cancellationToken);

            return response ?? default;
        } catch 
        {
            return default;
        }
    }
}
