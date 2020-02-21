using PiApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Core.UnitOfWork
{
    public interface IUnitOfWorkAsync:IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class;
    }
}
