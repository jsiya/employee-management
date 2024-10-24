using EmployeeManagement.Application.DTOs.DepartmentDTOs;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryResponse
{
    public DepartmentDto Departments { get; set; }
}