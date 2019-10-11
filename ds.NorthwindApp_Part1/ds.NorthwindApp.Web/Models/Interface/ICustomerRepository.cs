using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Interface
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customers customer);

        Task UpdateAsync(Customers customer);

        Task DeleteAsync(Customers customer);

        Task<Customers> GetOneAsync(string id);

        Task<IEnumerable<Customers>> GetAllAsync();

        Task<bool> ExistsAsync(string id);
    }
}
