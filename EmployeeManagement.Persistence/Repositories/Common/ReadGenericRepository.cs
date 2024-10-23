using System.Linq.Expressions;
using EmployeeManagement.Application.Interfaces.Repositories.Common;
using EmployeeManagement.Domain.Entities.Abstracts;
using EmployeeManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Common;

public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity
{
    public ReadGenericRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool noTracking = true)
    {
        if (noTracking)
        {
            if (expression == null)
            {
                return await _table.AsNoTracking().ToListAsync();
            }
            else
            {
                return await _table.AsNoTracking().Where(expression).ToListAsync();
            }
        }
        else
        {
            if (expression == null)
            {
                return await _table.ToListAsync();
            }
            else
            {
                return await _table.ToListAsync();
            }
        }
    }
    
    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool noTracking = false)
    {
        if (noTracking)
        {
            return  await _table.AsNoTracking().FirstOrDefaultAsync(expression);
        }
        else
        {
            return await _table.FirstOrDefaultAsync(expression);
        }
    }
    
}