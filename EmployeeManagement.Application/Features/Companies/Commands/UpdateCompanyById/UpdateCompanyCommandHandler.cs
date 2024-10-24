using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;

public class UpdateCompanyCommandHandler: IRequestHandler<UpdateCompanyCommandRequest, int>
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

    public async Task<int> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        _mapper.Map(request, company);
        if(company is not null)
        {
            _companyWriteRepository.Update(company);
            
            await _companyWriteRepository.SaveChangeAsync();
            return 1;
        }

        return 0;
    }
}