using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ds.NorthwindApp.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Model.Repository {
    public class SupplierRepository : GenericRepository<Suppliers>, ISupplierRepository {
        public SupplierRepository (NorthwindContext northwindContext) : base (northwindContext) { }

        public async Task CreateAsync (Suppliers supplier) {
            if (supplier == null) {
                throw new ArgumentNullException ("customer");
            } else {
                this.Create (supplier);
                await SaveAsync ();
            }
        }

        public async Task UpdateAsync (Suppliers supplier) {
            if (supplier == null) {
                throw new ArgumentNullException ("supplier");
            } else {
                this.Update (supplier);
                await SaveAsync ();
            }
        }

        public async Task DeleteAsync (Suppliers supplier) {
            if (supplier == null) {
                throw new ArgumentNullException ("supplier");
            } else {
                this.Delete (supplier);
                await SaveAsync ();
            }
        }

        public async Task<Suppliers> GetOneByIdAsync (int id) {
            return await this.GetByCondition (x => x.SupplierId == id).FirstOrDefaultAsync ();
        }

        public async Task<IEnumerable<Suppliers>> GetAllAsync () {
            return await this.GetAll ().ToListAsync ();
        }

        public async Task<bool> ExistAsync (int id) {
            return await GetByCondition (x => x.SupplierId == id).AnyAsync ();
        }

    }
}