using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Utilities.Responses;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryResponse: PaginatedDataResult<EmployeeDto>
{
    public GetAllEmployeesQueryResponse(IEnumerable<EmployeeDto> items, int totalCount, int pageSize, int pageNumber)
        : base(
            items,
            totalCount,
            pageSize,
            pageNumber,
            hasNext: pageNumber < (int)Math.Floor((double)totalCount / pageSize),
            hasPrevious: pageNumber > 1
        )
    {
    }
}