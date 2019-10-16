using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Model.UnitOfWork;
using ds.NorthwindApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IRepository<Customers> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IRepository<Customers> repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> CreateAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Create(customer);
                await _unitOfWork.Commit();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<IResult> UpdateAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Update(customer);
                await _unitOfWork.Commit();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<IResult> DeleteAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Delete(customer);
                await _unitOfWork.Commit();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }


        public async Task<Customers> GetOneByIdAsync(string id)
        {
            return await _repository.GetByCondition(x => x.CustomerId == id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<bool> ExistAsync(string id)
        {
            return await _repository.GetByCondition(x => x.CustomerId == id).AnyAsync();
        }

    }
}
