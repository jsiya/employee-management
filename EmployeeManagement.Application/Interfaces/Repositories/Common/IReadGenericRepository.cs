using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Application.Interfaces.Repositories.Common;

public interface IReadGenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
{
    
}