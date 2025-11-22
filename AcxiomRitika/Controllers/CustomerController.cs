using AcxiomRitika.Data;
using AcxiomRitika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomRitika.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // ------------------- INDEX -------------------
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // ------------------- CREATE (GET) -------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ------------------- CREATE (POST) -------------------
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // ------------------- EDIT (GET) -------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        // ------------------- EDIT (POST) -------------------
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ------------------- DETAILS -------------------
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        // ------------------- DELETE (GET) -------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        // ------------------- DELETE (POST) -------------------
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
