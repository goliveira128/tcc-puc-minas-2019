using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentesSGQ.Data.Repository.Base
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(string id);
        List<TEntity> GetAll();
        void Insert(TEntity entity);
        void InsertAll(List<TEntity> entitys);
        void Update(TEntity entity);
        void UpdateAll(List<TEntity> entitys);
        void Delete(TEntity entity);
        void DeleteAll(List<TEntity> entitys);
        void ExecuteUnderTransaction(Action action);
    }
}
