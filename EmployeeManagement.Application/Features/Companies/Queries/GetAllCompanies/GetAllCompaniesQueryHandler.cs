using AutoMapper;
using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler: IRequestHandler<GetAllCompaniesQueryRequest, GetAllCompaniesQueryResponse>
{
    private readonly ICompanyReadRepository _companyReadRepository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
    {
        _companyReadRepository = companyReadRepository;
        _mapper = mapper;
    }


    public async Task<GetAllCompaniesQueryResponse> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
    {
        var companies = await _companyReadRepository.GetAllAsync();
        var companiesForPage = companies.ToList()
            .Skip((request.Page-1) * request.PageSize)
            .Take(request.PageSize).ToList();

        return new GetAllCompaniesQueryResponse()
        {
            Companies = _mapper.Map<ICollection<CompanyDto>>(companiesForPage)
        };
    }
}