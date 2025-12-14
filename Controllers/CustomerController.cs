using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMembershipService _membershipService;

        public CustomerController(ICustomerService customerService, IMembershipService membershipService)
        {
            _customerService = customerService;
            _membershipService = membershipService;
        }

        // Liste paginée
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;
            var customers = await _customerService.GetCustomersPaginatedAsync(pageNumber, pageSize);


            return View(customers);
        }

        // Détails
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // Création
        public async Task<IActionResult> Create()
        {
            ViewBag.MembershipTypes = new SelectList(await _membershipService.GetAllAsync(), "Id", "DurationInMonth");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Errors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .ToList();

            ViewBag.MembershipTypes = new SelectList(await _membershipService.GetAllAsync(), "Id", "DurationInMonth", customer.MembershipTypeId);
            return View(customer);
        }

        // Edition
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            ViewData["MembershipTypeId"] = new SelectList(await _membershipService.GetAllAsync(), "Id", "DurationInMonth", customer.MembershipTypeId);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _customerService.UpdateCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }

            ViewData["MembershipTypeId"] = new SelectList(await _membershipService.GetAllAsync(), "Id", "DurationInMonth", customer.MembershipTypeId);
            return View(customer);
        }

        // Suppression
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            await _customerService.DeleteCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        // Méthode spécifique : clients abonnés avec discount > 10%
        public IActionResult SubscribedWithDiscount()
        {
            var customers = _customerService.GetSubscribedCustomersWithDiscount();
            return View(customers);
        }
    }
}
