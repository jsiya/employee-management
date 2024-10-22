namespace EmployeeManagement.Domain.Entities.Abstracts;

public interface IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}