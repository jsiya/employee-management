namespace EmployeeManagement.Application.DTOs.DepartmentDTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
}