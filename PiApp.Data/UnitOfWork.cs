using PiApp.Core.Repositories;
using PiApp.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Data
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        private readonly DbContext _dbcontext;
        private Dictionary<string, dynamic> Repositories;
        public UnitOfWork(DbContext dbconext)
        {
            _dbcontext = dbconext;
            Repositories = new Dictionary<string, dynamic>();
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;
            if(Repositories.ContainsKey(type)) //da~ instance
            {
                return Repositories[type];
            }

            //chua instance
            var repositoryType = typeof(Repository<>);

            /* Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbcontext, this));*/ // ???
            Repositories.Add(type, new Repository<TEntity>(_dbcontext));
            return Repositories[type];
        }

        public int SaveChange()
        {
            return _dbcontext.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            return _dbcontext.SaveChangesAsync();
        }
    }
}
