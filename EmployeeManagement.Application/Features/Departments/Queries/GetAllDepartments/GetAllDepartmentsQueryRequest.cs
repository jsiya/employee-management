using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQueryRequest: IRequest<GetAllDepartmentsQueryResponse>
{
    public int? CompanyId { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}