using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity obj);
        Task Delete(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<IList<TEntity>> Get();
        Task<TEntity> GetById(int id);
    }
}
