using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;

public class DeleteEmployeeByIdCommandRequest: IRequest
{
    public int Id { get; set; }
}