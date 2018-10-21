using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
