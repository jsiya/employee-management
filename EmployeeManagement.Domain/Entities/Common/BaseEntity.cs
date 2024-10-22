using EmployeeManagement.Domain.Entities.Abstracts;

namespace EmployeeManagement.Domain.Entities.Common;

public class BaseEntity: IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}