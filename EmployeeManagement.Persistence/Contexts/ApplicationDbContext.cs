using EmployeeManagement.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Company> Companies { get; set; }

}