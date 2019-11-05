using ds.NorthwindApp.Web.Models.Interface;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Repository
{
    public class SupplierRepository : GenericRepository<Suppliers>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext northwindContext)
            : base(northwindContext)
        {
        }

        public async Task<Suppliers> GetOneByIdAsync(int id)
        {
            return await this.GetOneAsync(x => x.SupplierId == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.ExistAsync(x => x.SupplierId == id);
        }

    }
}

