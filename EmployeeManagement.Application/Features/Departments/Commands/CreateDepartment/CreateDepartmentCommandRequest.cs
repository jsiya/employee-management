using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandRequest: IRequest<IDataResult<int>>
{
    public string Name { get; set; }
    public int CompanyId { get; set; }
}