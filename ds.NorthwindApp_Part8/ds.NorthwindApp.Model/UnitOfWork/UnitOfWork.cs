using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Model.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Func<NorthwindContext> _factory;
        private NorthwindContext _dbContext;

        public UnitOfWork(Func<NorthwindContext> func)
        {
            _factory = func;
            _dbContext = _factory.Invoke();
        }

        public NorthwindContext DbContext()
        {
            return _dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
