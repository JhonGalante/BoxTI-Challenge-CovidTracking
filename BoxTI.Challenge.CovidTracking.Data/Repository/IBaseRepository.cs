using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task Insert(TEntity obj);
        public Task Update(TEntity obj);
        public Task Delete(TEntity obj);
        Task<IList<TEntity>> Get();
        Task<TEntity> GetById(int id);
    }
}
