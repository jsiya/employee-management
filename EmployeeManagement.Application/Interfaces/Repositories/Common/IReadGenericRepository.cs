using System.Linq.Expressions;
using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Application.Interfaces.Repositories.Common;

public interface IReadGenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
{
    public  Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool noTracking = true);
    public Task<T> GetAsync(Expression<Func<T, bool>> expression, bool noTracking = false);
}