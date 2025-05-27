
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using White_Horse_Inc_Api.Data.Mappings;
using White_Horse_Inc_Core.Requests.UserInformations;

namespace White_Horse_Inc_Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        DbSet<UserInformationsMapping> UserInformations { get; set; } = null!;
        DbSet<UserAddressMapping> UserAddress { get; set; } = null!;
        DbSet<CompanyRoleMapping> CompanyRole { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
