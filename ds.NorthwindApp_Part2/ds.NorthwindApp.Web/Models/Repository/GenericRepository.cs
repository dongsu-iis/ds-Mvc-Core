using ds.NorthwindApp.Web.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        private readonly NorthwindContext db;

        public GenericRepository(NorthwindContext context)
        {
            db = context;
        }

        public async Task CreateAsync(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                await db.Set<TEntity>().AddAsync(instance);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Set<TEntity>().Update(instance);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Set<TEntity>().Remove(instance);
                await db.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await db.Set<TEntity>().AnyAsync(expression);
        }

    }
}
