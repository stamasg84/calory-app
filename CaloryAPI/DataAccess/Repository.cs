using Core.Interfaces;
using DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CaloryDbContext dbContext;

        public Repository(CaloryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(IEnumerable<TEntity> models)
        {
            foreach (var model in models)
            {
                dbContext.Set<TEntity>().Add(model);
            }
            
            dbContext.SaveChanges();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> result = dbContext.Set<TEntity>();

            if(filter != null)
            {
                result = result.Where(filter);
            }
            return result.ToList();
        }

        public int Sum(Expression<Func<TEntity, int>> fieldSelector, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> entities = dbContext.Set<TEntity>();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            return entities.Sum(fieldSelector);
        }
    }
}
