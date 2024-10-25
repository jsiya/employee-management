using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Utilities.Responses;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryResponse: PaginatedDataResult<CompanyDto>
{
    public GetAllCompaniesQueryResponse(IEnumerable<CompanyDto> items, int totalCount, int pageSize, int pageNumber)
        : base(items, totalCount, pageSize, pageNumber, hasNext: pageNumber * pageSize < totalCount, hasPrevious: pageNumber > 1)
    {
    }
}