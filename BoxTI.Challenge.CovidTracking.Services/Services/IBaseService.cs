using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Services.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity obj);
        void Delete(int id);
        TEntity Update(TEntity obj);
        IList<TEntity> Get();
        TEntity GetById(int id);
    }
}
