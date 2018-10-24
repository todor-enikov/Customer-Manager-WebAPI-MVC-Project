using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CustomerManager.Data
{
    public interface INorthwindDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
