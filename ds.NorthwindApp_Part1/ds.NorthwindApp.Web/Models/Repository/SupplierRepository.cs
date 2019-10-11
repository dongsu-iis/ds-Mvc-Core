using ds.NorthwindApp.Web.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Web.Models.Repository
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly NorthwindContext db;


        public SupplierRepository(NorthwindContext context)
        {
            db = context;
        }

        public async Task CreateAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }
            else
            {
                await db.Suppliers.AddAsync(supplier);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }
            else
            {
                db.Suppliers.Update(supplier);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Suppliers supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier");
            }
            else
            {
                db.Suppliers.Remove(supplier);
                await db.SaveChangesAsync();
            }
        }


        public async Task<Suppliers> GetOneAsync(int id)
        {
            return await db.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
        }

        public async Task<IEnumerable<Suppliers>> GetAllAsync()
        {
            return await db.Suppliers.ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await db.Suppliers.AnyAsync(x => x.SupplierId == id);
        }


    }
}
