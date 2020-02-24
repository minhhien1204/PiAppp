using PiApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _repository;
        public Service(IRepositoryAsync<TEntity> repository) // DI
        {
            _repository = repository;
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
