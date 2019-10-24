using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IRepository<Customers> _repository;

        public CustomerService(IRepository<Customers> repository)
        {
            _repository = repository;
        }

        public IResult Create(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Create(customer);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public IResult Update(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Update(customer);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public IResult Delete(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            IResult result = new Result(false);

            try
            {
                _repository.Delete(customer);
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

        public async Task<IEnumerable<Customers>> GetAllToListAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public IQueryable<Customers> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<bool> ExistAsync(string id)
        {
            return await _repository.GetByCondition(x => x.CustomerId == id).AnyAsync();
        }


    }
}
