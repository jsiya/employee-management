using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Application.Interfaces.Repositories.Common;

public interface IGenericRepository<T> where T : class, IBaseEntity
{
    
}