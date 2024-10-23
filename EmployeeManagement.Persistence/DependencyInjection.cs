using EmployeeManagement.Application.Interfaces.Repositories.Common;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Persistence.Contexts;
using EmployeeManagement.Persistence.Repositories.Common;
using EmployeeManagement.Persistence.Repositories.Read;
using EmployeeManagement.Persistence.Repositories.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            ConfigurationBuilder configurationBuilder = new();
            var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();

            options.UseLazyLoadingProxies()
                .UseSqlServer(builder.GetConnectionString("default"));
        });
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IReadGenericRepository<>), typeof(ReadGenericRepository<>));
        services.AddScoped(typeof(IWriteGenericRepository<>), typeof(WriteGenericRepository<>));
        services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
        services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
        services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
        services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
        services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
        services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

        return services;
    }
}