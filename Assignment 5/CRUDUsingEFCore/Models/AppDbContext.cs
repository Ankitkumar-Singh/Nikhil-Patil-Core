using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
