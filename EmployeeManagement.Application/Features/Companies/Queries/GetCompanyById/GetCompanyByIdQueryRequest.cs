using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryRequest: IRequest<IDataResult<CompanyDto>>
{
    public int Id { get; set; }
}