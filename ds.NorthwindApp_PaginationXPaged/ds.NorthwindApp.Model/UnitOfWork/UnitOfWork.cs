using System.Threading.Tasks;

namespace ds.NorthwindApp.Model.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _northwindContext;

        public UnitOfWork(NorthwindContext context)
        {
            _northwindContext = context;
        }

        public async Task Commit()
        {
            await _northwindContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _northwindContext.Dispose();
        }
    }
}
