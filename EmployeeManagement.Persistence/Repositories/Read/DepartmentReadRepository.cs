using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Read;

public class DepartmentReadRepository: ReadGenericRepository<Department>, IDepartmentReadRepository
{
    public DepartmentReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}