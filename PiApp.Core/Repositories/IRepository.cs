using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Queryable();    //get all entities
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object key);
    }
}
