using System.Linq.Expressions;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Read;

public class DepartmentReadRepository: ReadGenericRepository<Department>, IDepartmentReadRepository
{
    public DepartmentReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> expression = null, bool noTracking = true)
    {
        if (expression is not null)
        {
            return await _context.Departments
                .Where(expression)
                .Include(d => d.Company) 
                .ToListAsync();
        }
        else
        {
            return await _context.Departments
                .Include(d => d.Company) 
                .ToListAsync();
        }
    }
}