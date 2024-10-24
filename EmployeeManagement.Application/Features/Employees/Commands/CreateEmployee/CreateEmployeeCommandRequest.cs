using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandRequest: IRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }
}