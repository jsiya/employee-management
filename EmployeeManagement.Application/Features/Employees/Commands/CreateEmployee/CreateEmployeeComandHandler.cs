using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeComandHandler: IRequestHandler<CreateEmployeeCommandRequest>
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

    public async Task Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var departmentExists = await _departmentReadRepository.GetAsync(d => d.Id == request.DepartmentId);
            if (departmentExists == null)
            {
                throw new Exception($"Department with ID {request.DepartmentId} does not exist.");
            }
            var employee = _mapper.Map<Employee>(request);
            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}