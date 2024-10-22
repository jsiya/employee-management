using EmployeeManagement.Application.Interfaces.Repositories.Common;

namespace EmployeeManagement.Application.Interfaces.Repositories.Employee;

public interface IEmployeeWriteRepository: IWriteGenericRepository<Domain.Entities.Concretes.Employee>
{
    
}