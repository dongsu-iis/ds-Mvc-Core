using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface ISupplierRepository : IRepository<Suppliers>
    {
        Task<Suppliers> GetOneByIdAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}
