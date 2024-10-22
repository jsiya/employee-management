using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(p=>p.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}