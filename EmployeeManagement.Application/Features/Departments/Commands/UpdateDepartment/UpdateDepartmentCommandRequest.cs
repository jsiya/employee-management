using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandRequest: IRequest<IDataResult<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}