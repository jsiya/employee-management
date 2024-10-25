using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Utilities.Responses;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;

public class UpdateCompanyCommandHandler: IRequestHandler<UpdateCompanyCommandRequest, IDataResult<int>>
{
    private readonly ICompanyReadRepository _companyReadRepository;
    private readonly ICompanyWriteRepository _companyWriteRepository;
    private readonly IMapper _mapper;

    public UpdateCompanyCommandHandler(ICompanyReadRepository companyReadRepository, ICompanyWriteRepository companyWriteRepository, IMapper mapper)
    {
        _companyReadRepository = companyReadRepository;
        _companyWriteRepository = companyWriteRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<int>> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        
        if (company == null)
        {
            return new ErrorDataResult<int>(0, "Company not found.");
        }

        _mapper.Map(request, company);
        _companyWriteRepository.Update(company);
        await _companyWriteRepository.SaveChangeAsync();

        return new SuccessDataResult<int>(company.Id, "Company updated successfully.");
    }
}