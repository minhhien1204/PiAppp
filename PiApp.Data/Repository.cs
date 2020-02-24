using PiApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PiApp.Data
{
    public class Repository<TEntity> : IRepository<TEntity>, IRepositoryAsync<TEntity> where TEntity : class
    {
        public DbContext _dbcontext;
        public DbSet<TEntity> _dbset;
        public Repository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbset = _dbcontext.Set<TEntity>();
        }
        public IQueryable<TEntity> Queryable()
        {
            return _dbset;
        }
        public void Delete(object key)
        {
            var entity = _dbset.Find(key);
            _dbset.Attach(entity);
            _dbset.Remove(entity);
        }

        public Task<bool> DeleteAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbset.Find(keyValues);
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbset.Attach(entity);
        }
    }
}
