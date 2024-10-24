using EmployeeManagement.Domain.Entities.Abstracts;
using EmployeeManagement.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.EnableSensitiveDataLogging();
        
        base.OnConfiguring(optionsBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

        foreach (var item in datas)
        {
            if (item.Entity is IBaseEntity entity)
            {
                if (item.State == EntityState.Added)
                    entity.CreatedDate = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Company> Companies { get; set; }

}