using PiApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChange();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;   //...
    }
}
