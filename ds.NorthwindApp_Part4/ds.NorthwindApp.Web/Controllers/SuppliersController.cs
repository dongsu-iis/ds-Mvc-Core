using System.Threading.Tasks;
using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Web.Controllers {
    public class SuppliersController : Controller {
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController (ISupplierRepository supplierRepository) {
            _supplierRepository = supplierRepository;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index () {
            return View (await _supplierRepository.GetAllAsync ());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var suppliers = await _supplierRepository.GetOneByIdAsync (id.Value);

            if (suppliers == null) {
                return NotFound ();
            }

            return View (suppliers);
        }

        // GET: Suppliers/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Suppliers suppliers) {
            if (ModelState.IsValid) {
                await _supplierRepository.CreateAsync (suppliers);
                return RedirectToAction (nameof (Index));
            }
            return View (suppliers);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var suppliers = await _supplierRepository.GetOneByIdAsync (id.Value);
            if (suppliers == null) {
                return NotFound ();
            }
            return View (suppliers);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Suppliers suppliers) {
            if (id != suppliers.SupplierId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    await _supplierRepository.UpdateAsync (suppliers);
                } catch (DbUpdateConcurrencyException) {
                    if (!await _supplierRepository.ExistAsync (suppliers.SupplierId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (suppliers);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var suppliers = await _supplierRepository.GetOneByIdAsync (id.Value);

            if (suppliers == null) {
                return NotFound ();
            }

            return View (suppliers);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {

            var suppliers = await _supplierRepository.GetOneByIdAsync (id);
            await _supplierRepository.DeleteAsync (suppliers);
            return RedirectToAction (nameof (Index));
        }

    }
}