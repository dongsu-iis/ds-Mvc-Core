using ds.NorthwindApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service.Interface
{
    public interface ICustomerService
    {
        IResult Create(Customers customer);

        IResult Update(Customers customer);

        IResult Delete(Customers customer);

        Task<Customers> GetOneByIdAsync(string id);

        Task<IEnumerable<Customers>> GetAllAsync();

        Task<bool> ExistAsync(string id);
    }
}
