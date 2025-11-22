using System.Collections.Generic;

namespace AcxiomRitika.Models
{
    public class DashboardViewModel
    {
        public string SearchTerm { get; set; }

        // Totals (optional display)
        public int TotalEmployees { get; set; }
        public int TotalCustomers { get; set; }

        // Results to show (either search results or few latest)
        public List<Employee> EmployeeResults { get; set; } = new List<Employee>();
        public List<Customer> CustomerResults { get; set; } = new List<Customer>();
    }
}
