using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Domain.Entities.Concretes;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;

namespace EmployeeManagement.Persistence.Repositories.Write;

public class CompanyWriteRepository: WriteGenericRepository<Company>, ICompanyWriteRepository
{
    public CompanyWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}