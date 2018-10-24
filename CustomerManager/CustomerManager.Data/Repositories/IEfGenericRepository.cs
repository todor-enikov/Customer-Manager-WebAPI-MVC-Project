using System.Collections.Generic;

namespace CustomerManager.Data.Repositories
{
    public interface IEfGenericRepository<T>
          where T : class
    {
        IEnumerable<T> All();

        IEnumerable<T> AllIncludeChildEntity(string entity);

        T GetById(object id);
    }
}
