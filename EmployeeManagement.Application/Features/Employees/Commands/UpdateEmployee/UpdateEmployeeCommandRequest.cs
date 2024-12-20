using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandRequest: IRequest<IDataResult<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }
}