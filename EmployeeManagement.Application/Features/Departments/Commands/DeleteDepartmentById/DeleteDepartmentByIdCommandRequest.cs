using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartmentById;

public class DeleteDepartmentByIdCommandRequest: IRequest<IDataResult<int>>
{
    public int Id { get; set; }
}