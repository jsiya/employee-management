using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Read;

public class CompanyReadRepository: ReadGenericRepository<Company>, ICompanyReadRepository
{
    public CompanyReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}