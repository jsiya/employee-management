using EmployeeManagement.Domain.Entities.Common;

namespace EmployeeManagement.Domain.Entities.Concretes;

public class Employee: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }

    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}