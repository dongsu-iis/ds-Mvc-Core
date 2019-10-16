using System.Threading.Tasks;
using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ds.NorthwindApp.Web.Controllers {
    public class CustomersController : Controller {

        private readonly ICustomerRepository _customerRepository;

        public CustomersController (ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        // GET: Customers
        public async Task<IActionResult> Index () {
            return View (await _customerRepository.GetAllAsync ());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details (string id) {
            if (id == null) {
                return NotFound ();
            }

            var customers = await _customerRepository.GetOneByIdAsync (id);
            if (customers == null) {
                return NotFound ();
            }

            return View (customers);
        }

        // GET: Customers/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customers customers) {
            if (ModelState.IsValid) {
                await _customerRepository.CreateAsync (customers);
                return RedirectToAction (nameof (Index));
            }
            return View (customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit (string id) {
            if (id == null) {
                return NotFound ();
            }

            var customers = await _customerRepository.GetOneByIdAsync (id);
            if (customers == null) {
                return NotFound ();
            }
            return View (customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id, [Bind ("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customers customers) {
            if (id != customers.CustomerId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    await _customerRepository.UpdateAsync (customers);
                } catch (DbUpdateConcurrencyException) {
                    if (!await _customerRepository.ExistAsync (customers.CustomerId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete (string id) {
            if (id == null) {
                return NotFound ();
            }

            var customers = await _customerRepository.GetOneByIdAsync (id);
            if (customers == null) {
                return NotFound ();
            }

            return View (customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id) {
            var customers = await _customerRepository.GetOneByIdAsync (id);
            await _customerRepository.DeleteAsync (customers);
            return RedirectToAction (nameof (Index));
        }
    }
}