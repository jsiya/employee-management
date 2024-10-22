using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Application.Interfaces.Repositories.Common;

public interface IWriteGenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
{
    
}