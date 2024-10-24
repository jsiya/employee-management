using AutoMapper;
using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandler: IRequestHandler<GetCompanyByIdQueryRequest, GetCompanyByIdQueryResponse>
{
    private readonly ICompanyReadRepository _companyReadRepository;
    private readonly IMapper _mapper;

    public GetCompanyByIdQueryHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
    {
        _companyReadRepository = companyReadRepository;
        _mapper = mapper;
    }

    public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        return new GetCompanyByIdQueryResponse()
        {
            Company = _mapper.Map<CompanyDto>(company)
        };
    }
}