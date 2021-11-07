using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repo;

        public BaseService(IBaseRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _repo.Insert(obj);
            return obj;
        }

        public async Task Delete(TEntity obj)
        {
            await _repo.Delete(obj);
        }

        public async Task<IList<TEntity>> Get()
        {
            return await _repo.Get();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            await _repo.Update(obj);
            return obj;
        }
    }
}
