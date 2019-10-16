using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);

        Task SaveAsync();
    }
}
