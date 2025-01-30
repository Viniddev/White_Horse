using Microsoft.EntityFrameworkCore;

namespace White_Horse_Inc_Api.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DataSource=app.db;Cache=Shared");
        }
    }
}
