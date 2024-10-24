using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandRequest: IRequest
{
    public int Id { get; set; }
}