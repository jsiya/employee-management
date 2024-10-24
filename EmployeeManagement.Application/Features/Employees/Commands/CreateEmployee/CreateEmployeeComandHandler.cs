using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeComandHandler: IRequestHandler<CreateEmployeeCommandRequest>
{
    private readonly IEmployeeWriteRepository _employeeWriteRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeComandHandler(IEmployeeWriteRepository employeeWriteRepository, IMapper mapper)
    {
        _employeeWriteRepository = employeeWriteRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        await _employeeWriteRepository.AddAsync(employee);
        await _employeeWriteRepository.SaveChangeAsync();
    }
}