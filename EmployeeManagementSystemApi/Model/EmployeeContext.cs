using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            this.SeedInitialData();
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
