using ds.NorthwindApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service.Interface
{
    public interface ICustomerService
    {
        IResult Create(Customers customer);

        IResult Update(Customers customer);

        IResult Delete(Customers customer);

        Task<Customers> GetOneByIdAsync(string id);

        Task<IEnumerable<Customers>> GetAllToListAsync();

        IQueryable<Customers> GetAll();

        Task<bool> ExistAsync(string id);
    }
}
