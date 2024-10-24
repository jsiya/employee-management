using EmployeeManagement.Application.DTOs.DepartmentDTOs;

namespace EmployeeManagement.Application.DTOs.EmployeeDTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }

    // Nested Department DTO
    public DepartmentDto Department { get; set; }
}