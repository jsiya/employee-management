using System.Linq.Expressions;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Read;

public class EmployeeReadRepository: ReadGenericRepository<Employee>, IEmployeeReadRepository
{
    public EmployeeReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null, bool noTracking = true)
    {
        if (expression is not null)
        {
            return await _context.Employees
                .Where(expression)
                .Include(e => e.Department.Company)
                .ToListAsync();
        }
        else
        {
            return await _context.Employees
                .Include(d => d.Department.Company) 
                .ToListAsync();
        }
    }
}