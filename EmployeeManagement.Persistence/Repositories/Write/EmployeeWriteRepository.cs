using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Write;

public class EmployeeWriteRepository: WriteGenericRepository<Employee>, IEmployeeWriteRepository
{
    public EmployeeWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}