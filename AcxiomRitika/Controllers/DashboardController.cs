



using AcxiomRitika.Data;
using AcxiomRitika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomRitika.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Dashboard/Index?q=searchtext
        public IActionResult Index(string q)
        {
            var vm = new DashboardViewModel();
            vm.SearchTerm = q ?? string.Empty;

            // Totals
            vm.TotalEmployees = _context.Employees?.Count() ?? 0;
            vm.TotalCustomers = _context.Customers?.Count() ?? 0;

            if (!string.IsNullOrWhiteSpace(q))
            {
                var term = q.Trim().ToLower();

                // Employee search: name, designation, email
                vm.EmployeeResults = _context.Employees
                    .Where(e =>
                        (e.EmpName != null && e.EmpName.ToLower().Contains(term)) ||
                        (e.Designation != null && e.Designation.ToLower().Contains(term)) ||
                        (e.Email != null && e.Email.ToLower().Contains(term)))
                    .OrderByDescending(e => e.Id)
                    .Take(20) // limit results
                    .ToList();

                // Customer search: name, email, phone
                vm.CustomerResults = _context.Customers
                    .Where(c =>
                        (c.CustName != null && c.CustName.ToLower().Contains(term)) ||
                        (c.Email != null && c.Email.ToLower().Contains(term)) ||
                        (c.Phone != null && c.Phone.ToLower().Contains(term)))
                    .OrderByDescending(c => c.Id)
                    .Take(20)
                    .ToList();
            }
            else
            {
                // No search: show latest 5 of each for quick glance
                vm.EmployeeResults = _context.Employees
                    .OrderByDescending(e => e.Id)
                    .Take(5)
                    .ToList();

                vm.CustomerResults = _context.Customers
                    .OrderByDescending(c => c.Id)
                    .Take(5)
                    .ToList();
            }

            return View(vm);
        }
    }
}
