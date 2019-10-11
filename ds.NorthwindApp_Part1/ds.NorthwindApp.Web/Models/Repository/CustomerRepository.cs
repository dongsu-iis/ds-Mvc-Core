using ds.NorthwindApp.Web.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly NorthwindContext db;

        public CustomerRepository(NorthwindContext context)
        {
            db = context;
        }

        public async Task CreateAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            else
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            else
            {
                db.Customers.Update(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            else
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Customers> GetOneAsync(string id)
        {
            return await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await db.Customers.AnyAsync(x => x.CustomerId == id);
        }


    }
}
