using EmployeeManagement.Application.DTOs.CompanyDTOs;

namespace EmployeeManagement.Application.DTOs.DepartmentDTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CompanyDto Company { get; set; }
}