using AutoMapper;
using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandler: IRequestHandler<GetCompanyByIdQueryRequest, IDataResult<CompanyDto>>
{
    private readonly ICompanyReadRepository _companyReadRepository;
    private readonly IMapper _mapper;

    public GetCompanyByIdQueryHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
    {
        _companyReadRepository = companyReadRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CompanyDto>> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        if (company == null)
        {
            return new ErrorDataResult<CompanyDto>(null, "Company not found.");
        }

        var companyDto = _mapper.Map<CompanyDto>(company);
        return new SuccessDataResult<CompanyDto>(companyDto, "Company retrieved successfully.");
    }
}