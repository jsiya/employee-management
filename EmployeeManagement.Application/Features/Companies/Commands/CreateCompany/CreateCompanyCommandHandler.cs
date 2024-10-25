using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Utilities.Responses;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommandRequest, IDataResult<int>>
{
    private readonly IMapper _mapper;
    private readonly ICompanyWriteRepository _companyWriteRepository;

    public CreateCompanyCommandHandler(IMapper mapper, ICompanyWriteRepository companyWriteRepository)
    {
        _mapper = mapper;
        _companyWriteRepository = companyWriteRepository;
    }

    public async Task<IDataResult<int>> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var company = _mapper.Map<Company>(request);
            await _companyWriteRepository.AddAsync(company);
            await _companyWriteRepository.SaveChangeAsync();
            return new SuccessDataResult<int>(company.Id, "Company created successfully.");
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<int>(0, $"An error occurred: {ex.Message}");
        }
    }
}