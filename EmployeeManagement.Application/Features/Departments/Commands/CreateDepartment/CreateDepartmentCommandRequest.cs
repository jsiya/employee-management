using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandRequest: IRequest
{
    public string Name { get; set; }
    public int CompanyId { get; set; }
}