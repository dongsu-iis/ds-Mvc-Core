using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Model.UnitOfWork;

namespace ds.NorthwindApp.Model.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        private readonly NorthwindContext db;


        public GenericRepository(NorthwindContext context)
        {
            db = context;
        }

        public void Create(TEntity instance)
        {
            db.Set<TEntity>().Add(instance);
        }

        public void Update(TEntity instance)
        {
            db.Set<TEntity>().Update(instance);
        }

        public void Delete(TEntity instance)
        {
            db.Set<TEntity>().Remove(instance);
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return db.Set<TEntity>().Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllPaginated(int currentPage, int pageSize = 10)
        {
            return db.Set<TEntity>().Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
    }
}