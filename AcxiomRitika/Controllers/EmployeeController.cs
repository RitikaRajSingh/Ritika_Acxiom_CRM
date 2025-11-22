using AcxiomRitika.Data;
using AcxiomRitika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomRitika.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // ------------------- INDEX (LIST) -------------------
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // ------------------- CREATE (GET) -------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ------------------- CREATE (POST) -------------------
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // ------------------- EDIT (GET) -------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        // ------------------- EDIT (POST) -------------------
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ------------------- DETAILS -------------------
        public IActionResult Details(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        // ------------------- DELETE (GET) -------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        // ------------------- DELETE (POST) -------------------
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
