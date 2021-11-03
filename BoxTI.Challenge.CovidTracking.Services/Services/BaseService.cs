using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using System.Collections.Generic;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repo;

        public BaseService(IBaseRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public TEntity Add(TEntity obj)
        {
            _repo.Insert(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IList<TEntity> Get()
        {
            return _repo.Get();
        }

        public TEntity GetById(int id)
        {
            return _repo.GetById(id);
        }

        public TEntity Update(TEntity obj)
        {
            _repo.Update(obj);
            return obj;
        }
    }
}
