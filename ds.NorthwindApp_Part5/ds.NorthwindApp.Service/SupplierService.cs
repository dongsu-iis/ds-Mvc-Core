using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service
{
    public class SupplierService : ISupplierService
    {

        private readonly IRepository<Suppliers> _repository;

        public SupplierService(IRepository<Suppliers> repository)
        {
            _repository = repository;
        }

        public async Task<IResult> CreateAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Create(supplier);
                await _repository.SaveAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<IResult> UpdateAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Update(supplier);
                await _repository.SaveAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<IResult> DeleteAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Delete(supplier);
                await _repository.SaveAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }


        public async Task<Suppliers> GetOneByIdAsync(int id)
        {
            return await _repository.GetByCondition(x => x.SupplierId == id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Suppliers>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _repository.GetByCondition(x => x.SupplierId == id).AnyAsync();
        }

    }
}
