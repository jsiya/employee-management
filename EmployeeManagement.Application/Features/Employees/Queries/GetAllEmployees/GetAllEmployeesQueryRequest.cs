using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryRequest: IRequest<GetAllEmployeesQueryResponse>
{
    public int? DepartmentId { get; set; }
    public int? CompanyId { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}