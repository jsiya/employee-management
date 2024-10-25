using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Application.Utilities.Responses;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeComandHandler: IRequestHandler<CreateEmployeeCommandRequest, IDataResult<int>>
{
    private readonly IEmployeeWriteRepository _employeeWriteRepository;
    private readonly IDepartmentReadRepository _departmentReadRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeComandHandler(IEmployeeWriteRepository employeeWriteRepository, IMapper mapper, IDepartmentReadRepository departmentReadRepository)
    {
        _employeeWriteRepository = employeeWriteRepository;
        _mapper = mapper;
        _departmentReadRepository = departmentReadRepository;
    }

    public async Task<IDataResult<int>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var departmentExists = await _departmentReadRepository.GetAsync(d => d.Id == request.DepartmentId);
            if (departmentExists == null)
            {
                return new ErrorDataResult<int>(0, $"Department with ID {request.DepartmentId} does not exist.");
            }

            var employee = _mapper.Map<Employee>(request);
            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveChangeAsync();

            return new SuccessDataResult<int>(employee.Id, "Employee created successfully.");
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<int>(0, $"An error occurred: {ex.Message}");
        }
    }
}