
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace White_Horse_Inc_Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<T> GetDbSet<T>() where T : class => Set<T>();

        //esse metodo aplica configurações iniciais ao banco se for sua primeira execucao
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.IsPublic &&
                    t.Namespace == "White_Horse_Inc_Core.Models");

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
