using EmployeeManagement.Application.DTOs.EmployeeDTOs;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryResponse
{
    public EmployeeDto Employee { get; set; }
}