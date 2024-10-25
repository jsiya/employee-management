using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;

public class DeleteEmployeeByIdCommandRequest: IRequest<IDataResult<int>>
{
    public int Id { get; set; }
}