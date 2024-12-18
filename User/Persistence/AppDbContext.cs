using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using User.Domain;
using User.Interfaces;

namespace User.Persistence
{
    public class AppDbContext : IAppDbContext
    {
        //public DbContext AppDbContext { get; set; }
        //public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        //{ 
        //}

        //public DbSet<AppUser> AppUsers { get; set; }

        //public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        //{
        //    return base.Add(entity);
        //}

    }
}
