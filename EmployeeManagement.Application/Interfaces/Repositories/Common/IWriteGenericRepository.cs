using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Application.Interfaces.Repositories.Common;

public interface IWriteGenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
{
    public  Task<T> AddAsync(T entity);
    public void Update(T entity);
    public void Remove(T entity);
    public  Task SaveChangeAsync();
}