using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IncidentesSGQ.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public BaseRepository()
        {
            _dbContext = new IncidenteContext();
        }

        private DbContext _dbContext;

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteAll(List<TEntity> entitys)
        {
            entitys.ForEach(e => {
                _dbContext.Entry(e).State = EntityState.Deleted;
                _dbContext.Set<TEntity>().Remove(e);
            });
            _dbContext.SaveChanges();
        }

        public void ExecuteUnderTransaction(Action action)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    action?.Invoke();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void InsertAll(List<TEntity> entitys)
        {
            entitys.ForEach(e => {
                _dbContext.Set<TEntity>().Add(e);
            });
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateAll(List<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
               // var updatedEntity = _dbContext.Set<TEntity>().FirstOrDefault(e => e == entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.Set<TEntity>().Update(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
