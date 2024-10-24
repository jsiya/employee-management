using EmployeeManagement.Application.DTOs.CompanyDTOs;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryResponse
{
    public ICollection<CompanyDto> Companies { get; set; }
}