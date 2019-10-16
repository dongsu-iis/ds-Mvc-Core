using System.Threading.Tasks;
using ds.NorthwindApp.Model;
using ds.NorthwindApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Web.Controllers
{
    public class SuppliersController : Controller {
        private readonly ISupplierService _supplierService;

        public SuppliersController (ISupplierService supplierService) {
            _supplierService = supplierService;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index () {
            return View (await _supplierService.GetAllAsync ());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var suppliers = await _supplierService.GetOneByIdAsync (id.Value);

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
                await _supplierService.CreateAsync (suppliers);
                return RedirectToAction (nameof (Index));
            }
            return View (suppliers);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var suppliers = await _supplierService.GetOneByIdAsync (id.Value);
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
                    await _supplierService.UpdateAsync (suppliers);
                } catch (DbUpdateConcurrencyException) {
                    if (!await _supplierService.ExistAsync (suppliers.SupplierId)) {
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

            var suppliers = await _supplierService.GetOneByIdAsync (id.Value);

            if (suppliers == null) {
                return NotFound ();
            }

            return View (suppliers);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {

            var suppliers = await _supplierService.GetOneByIdAsync (id);
            await _supplierService.DeleteAsync (suppliers);
            return RedirectToAction (nameof (Index));
        }

    }
}