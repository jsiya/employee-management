using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Read;

public class EmployeeReadRepository: ReadGenericRepository<Employee>, IEmployeeReadRepository
{
    public EmployeeReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}