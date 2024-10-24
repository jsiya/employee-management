using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryRequest: IRequest<GetAllCompaniesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}