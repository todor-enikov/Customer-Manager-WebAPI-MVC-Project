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

        T GetById(object id);
    }
}
