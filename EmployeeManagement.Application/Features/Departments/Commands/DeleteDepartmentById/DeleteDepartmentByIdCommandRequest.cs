using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartmentById;

public class DeleteDepartmentByIdCommandRequest: IRequest
{
    public int Id { get; set; }
}