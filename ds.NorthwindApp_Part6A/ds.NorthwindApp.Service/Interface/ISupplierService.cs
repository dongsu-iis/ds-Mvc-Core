using ds.NorthwindApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service.Interface
{
    public interface ISupplierService
    {
        Task<IResult> CreateAsync(Suppliers supplier);

        Task<IResult> UpdateAsync(Suppliers supplier);

        Task<IResult> DeleteAsync(Suppliers supplier);

        Task<Suppliers> GetOneByIdAsync(int id);

        Task<IEnumerable<Suppliers>> GetAllAsync();

        Task<bool> ExistAsync(int id);
    }
}
