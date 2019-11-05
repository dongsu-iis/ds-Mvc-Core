using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task CreateAsync(TEntity instance);

        Task UpdateAsync(TEntity instance);

        Task DeleteAsync(TEntity instance);

        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression);
    }
}
