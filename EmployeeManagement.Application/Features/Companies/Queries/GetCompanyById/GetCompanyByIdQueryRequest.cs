using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryRequest: IRequest<GetCompanyByIdQueryResponse>
{
    public int Id { get; set; }
}