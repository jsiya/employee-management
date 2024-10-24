using EmployeeManagement.Application.DTOs.DepartmentDTOs;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQueryResponse
{
    public ICollection<DepartmentDto> Departments { get; set; }
}