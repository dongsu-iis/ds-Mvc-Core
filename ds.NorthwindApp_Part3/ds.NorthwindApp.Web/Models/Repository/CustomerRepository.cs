using ds.NorthwindApp.Web.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Repository
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext northwindContext)
            :base(northwindContext)
        {
        }

        public async Task<Customers> GetOneByIdAsync(string id)
        {
            return await this.GetOneAsync(x => x.CustomerId == id);
        }

       

        public async Task<bool> ExistAsync(string id)
        {
            return await this.ExistAsync(x => x.CustomerId == id);
        }


    }
}
