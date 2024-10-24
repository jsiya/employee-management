using EmployeeManagement.Application.DTOs.EmployeeDTOs;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryResponse
{
    public ICollection<EmployeeDto> Employee { get; set; }
}