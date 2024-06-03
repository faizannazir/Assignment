using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Customer> customers = await _db.Customers.ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> Update(Guid id)
        {
            Customer? customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            Customer? customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
