using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Queryable();
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
