using EmployeeManagement.Application.Interfaces.Repositories.Common;
using EmployeeManagement.Domain.Entities.Abstracts;
using EmployeeManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Common;

public class GenericRepository<T>:IGenericRepository<T> where T : class,IBaseEntity
{
    protected readonly ApplicationDbContext _context;
    protected DbSet<T> _table;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
}