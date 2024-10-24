using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandRequest: IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}