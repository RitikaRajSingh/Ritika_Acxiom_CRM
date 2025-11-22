using AcxiomRitika.Data;
using AcxiomRitika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomRitika.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Reports/Index
        public IActionResult Index()
        {
            var vm = new ReportsViewModel();

            // Safely handle nulls if DbSet is not present
            vm.TotalEmployees = _context.Employees?.Count() ?? 0;
            vm.TotalCustomers = _context.Customers?.Count() ?? 0;

            // Get few employees and customers to show (e.g., latest 5 or first 5)
            // You can change ordering as per your requirement
            vm.FewEmployees = _context.Employees != null
                ? _context.Employees
                    .OrderByDescending(e => e.Id)   // latest first (change if you want)
                    .Take(5)
                    .ToList()
                : new List<Employee>();

            vm.FewCustomers = _context.Customers != null
                ? _context.Customers
                    .OrderByDescending(c => c.Id)
                    .Take(5)
                    .ToList()
                : new List<Customer>();

            return View(vm);
        }
    }
}
