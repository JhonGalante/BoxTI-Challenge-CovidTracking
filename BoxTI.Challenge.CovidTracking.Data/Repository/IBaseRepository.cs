using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public void Insert(TEntity obj);
        public void Update(TEntity obj);
        public void Delete(int id);
        IList<TEntity> Get();
        TEntity GetById(int id);
    }
}
