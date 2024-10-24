using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommandRequest, int>
{
    private readonly IMapper _mapper;
    private readonly ICompanyWriteRepository _companyWriteRepository;

    public CreateCompanyCommandHandler(IMapper mapper, ICompanyWriteRepository companyWriteRepository)
    {
        _mapper = mapper;
        _companyWriteRepository = companyWriteRepository;
    }

    public async Task<int> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(request);
        await _companyWriteRepository.AddAsync(company);
        await _companyWriteRepository.SaveChangeAsync();
        return company.Id;
    }
}