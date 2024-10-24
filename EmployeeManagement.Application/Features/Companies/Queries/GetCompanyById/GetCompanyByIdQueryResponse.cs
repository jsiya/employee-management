using EmployeeManagement.Application.DTOs.CompanyDTOs;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryResponse
{
    public CompanyDto Company { get; set; }
}