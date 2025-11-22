namespace AcxiomRitika.Models
{
    public class ReportsViewModel
    {
        // Totals
        public int TotalEmployees { get; set; }
        public int TotalCustomers { get; set; }

        // Sample lists (few entries to show)
        public List<Employee> FewEmployees { get; set; } = new List<Employee>();
        public List<Customer> FewCustomers { get; set; } = new List<Customer>();
    }
}
