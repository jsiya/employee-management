using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Write;

public class DepartmentWriteRepository: WriteGenericRepository<Department>, IDepartmentWriteRepository
{
    public DepartmentWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}