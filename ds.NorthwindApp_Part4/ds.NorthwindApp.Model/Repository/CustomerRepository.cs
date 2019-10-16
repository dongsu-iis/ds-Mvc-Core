using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ds.NorthwindApp.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Model.Repository {
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository {
        public CustomerRepository (NorthwindContext northwindContext) : base (northwindContext) { }

        public async Task CreateAsync (Customers customer) {
            if (customer == null) {
                throw new ArgumentNullException ("customer");
            } else {
                this.Create (customer);
                await SaveAsync ();
            }
        }

        public async Task UpdateAsync (Customers customer) {
            if (customer == null) {
                throw new ArgumentNullException ("customer");
            } else {
                this.Update (customer);
                await SaveAsync ();
            }
        }

        public async Task DeleteAsync (Customers customer) {
            if (customer == null) {
                throw new ArgumentNullException ("customer");
            } else {
                this.Delete (customer);
                await SaveAsync ();
            }
        }

        public async Task<Customers> GetOneByIdAsync (string id) {
            return await this.GetByCondition (x => x.CustomerId == id).FirstOrDefaultAsync ();
        }

        public async Task<IEnumerable<Customers>> GetAllAsync () {
            return await this.GetAll ().ToListAsync ();
        }

        public async Task<bool> ExistAsync (string id) {
            return await GetByCondition (x => x.CustomerId == id).AnyAsync ();
        }

    }
}