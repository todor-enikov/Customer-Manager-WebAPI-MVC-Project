using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Repositories
{
    public class EfGenericRepository<T> : IEfGenericRepository<T> where T : class
    {
        public EfGenericRepository(INorthwindDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected INorthwindDbContext Context { get; set; }

        public virtual IEnumerable<T> All()
        {
            return this.DbSet.AsEnumerable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }
    }
}

