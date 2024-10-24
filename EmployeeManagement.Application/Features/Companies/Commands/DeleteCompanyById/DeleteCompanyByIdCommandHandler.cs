using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;

public class DeleteCompanyByIdCommandHandler: IRequestHandler<DeleteCompanyByIdCommandRequest, int>
{
    private readonly ICompanyWriteRepository _companyWriteRepository;
    private readonly ICompanyReadRepository _companyReadRepository;

    public DeleteCompanyByIdCommandHandler(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
    {
        _companyWriteRepository = companyWriteRepository;
        _companyReadRepository = companyReadRepository;
    }
    
    public async Task<int> Handle(DeleteCompanyByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        if (company is not null)
        {
            _companyWriteRepository.Remove(company);
            await _companyWriteRepository.SaveChangeAsync();
            return 1;
        }

        return 0;
    }
}