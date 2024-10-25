using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Company;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler: IRequestHandler<CreateDepartmentCommandRequest>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentWriteRepository _departmentWriteRepository;
    private readonly ICompanyReadRepository _companyReadRepository;

    public CreateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository)
    {
        _departmentWriteRepository = departmentWriteRepository;
        _mapper = mapper;
        _companyReadRepository = companyReadRepository;
    }

    public async Task Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var companyExists = await _companyReadRepository.GetAsync(c => c.Id == request.CompanyId);
            if (companyExists == null)
            {
                throw new Exception($"Company with ID {request.CompanyId} does not exist.");
            }
            var department = _mapper.Map<Department>(request);
            await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }
}