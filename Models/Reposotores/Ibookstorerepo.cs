using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Reposotores
{
   public interface Ibookstorerepo<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void add(TEntity entety);
        void Update(int Id,TEntity entety);
        void Delete(int id);
    }
}
