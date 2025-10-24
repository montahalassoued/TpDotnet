using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;

            var customerQuery = _db.Customers
                .Include(c => c.MembershipType)
                .OrderBy(c => c.Id)
                .AsNoTracking();

            var customers = await PaginatedList<Customer>.CreateAsync(customerQuery, pageNumber, pageSize);
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            var customer = _db.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            ViewData["MembershipTypeId"] = new SelectList(
                _db.MembershipTypes,
                "Id",
                "DurationInMonth",
                customer.MembershipTypeId
            );

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Customers.Update(customer);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.Customers.Any(c => c.Id == customer.Id))
                        return NotFound();
                    throw;
                }
            }

            ViewData["MembershipTypeId"] = new SelectList(
                _db.MembershipTypes,
                "Id",
                "DurationInMonth",
                customer.MembershipTypeId
            );

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _db.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer == null)
                return NotFound();

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        

    public IActionResult Create()
        {
            ViewData["MembershipTypeId"] = new SelectList(_db.MembershipTypes, "Id", "DurationInMonth");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
        {
        if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        ViewBag.MembershipTypes = new SelectList(_db.MembershipTypes, "Id", "Name", customer.MembershipTypeId);
            return View(customer);
        }
    }
}
