using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        Task<Customers> GetOneByIdAsync(string id);

        Task<bool> ExistAsync(string id);
    }
}
