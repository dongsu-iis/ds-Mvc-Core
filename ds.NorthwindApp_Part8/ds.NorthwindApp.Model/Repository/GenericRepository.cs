using System;
using System.Linq;
using System.Linq.Expressions;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Model.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Model.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        private DbSet<TEntity> DbSet { get; set; }


        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DbSet = _unitOfWork.DbContext().Set<TEntity>();
        }

        public void Create(TEntity instance)
        {
            DbSet.Add(instance);
        }

        public void Update(TEntity instance)
        {
            DbSet.Update(instance);
        }

        public void Delete(TEntity instance)
        {
            DbSet.Remove(instance);
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
    }
}