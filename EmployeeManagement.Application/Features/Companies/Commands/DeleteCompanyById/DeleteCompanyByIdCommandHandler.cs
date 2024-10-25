using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;

public class DeleteCompanyByIdCommandHandler: IRequestHandler<DeleteCompanyByIdCommandRequest, IDataResult<int>>
{
    private readonly ICompanyWriteRepository _companyWriteRepository;
    private readonly ICompanyReadRepository _companyReadRepository;

    public DeleteCompanyByIdCommandHandler(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
    {
        _companyWriteRepository = companyWriteRepository;
        _companyReadRepository = companyReadRepository;
    }
    
    public async Task<IDataResult<int>> Handle(DeleteCompanyByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyReadRepository.GetAsync(c => c.Id == request.Id);
        
        if (company == null)
        {
            return new ErrorDataResult<int>(0, "Company not found.");
        }

        _companyWriteRepository.Remove(company);
        await _companyWriteRepository.SaveChangeAsync();
        
        return new SuccessDataResult<int>(company.Id, "Company deleted successfully.");
    }
}