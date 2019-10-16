using System.Collections.Generic;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface ICustomerRepository : IRepository<Customers>
    {

        Task CreateAsync(Customers customer);

        Task UpdateAsync(Customers customer);

        Task DeleteAsync(Customers customer);

        Task<Customers> GetOneByIdAsync(string id);

        Task<IEnumerable<Customers>> GetAllAsync();

        Task<bool> ExistAsync(string id);


    }
}
