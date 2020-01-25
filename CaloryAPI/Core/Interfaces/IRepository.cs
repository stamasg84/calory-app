using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        int Sum(Expression<Func<TEntity, int>> fieldSelector, Expression<Func<TEntity, bool>> filter = null);

        public void Create(IEnumerable<TEntity> models);
    }
}
