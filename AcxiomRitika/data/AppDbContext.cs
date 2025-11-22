using AcxiomRitika.Models;
using Microsoft.EntityFrameworkCore;
namespace AcxiomRitika.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}