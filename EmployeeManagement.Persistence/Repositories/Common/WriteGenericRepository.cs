using EmployeeManagement.Application.Interfaces.Repositories.Common;
using EmployeeManagement.Domain.Entities.Abstracts;
using EmployeeManagement.Persistence.Contexts;

namespace EmployeeManagement.Persistence.Repositories.Common;

public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity
{
    public WriteGenericRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<T> AddAsync(T entity)
    {
        await _table.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }
    
    public void Remove(T entity)
    {
        _table.Remove(entity);
    }
    
    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}