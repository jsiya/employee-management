using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Utilities.Responses;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQueryResponse : PaginatedDataResult<DepartmentDto>
{
    public GetAllDepartmentsQueryResponse(IEnumerable<DepartmentDto> items, int totalCount, int pageSize, int pageNumber)
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
