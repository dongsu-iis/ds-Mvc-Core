using System.Collections.Generic;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface {
    public interface ISupplierRepository {
        Task CreateAsync (Suppliers supplier);

        Task UpdateAsync (Suppliers supplier);

        Task DeleteAsync (Suppliers supplier);

        Task<Suppliers> GetOneAsync (int id);

        Task<IEnumerable<Suppliers>> GetAllAsync ();

        Task<bool> ExistsAsync (int id);
    }
}