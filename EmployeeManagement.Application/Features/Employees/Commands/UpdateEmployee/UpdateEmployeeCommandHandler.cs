using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler: IRequestHandler<UpdateEmployeeCommandRequest>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IEmployeeWriteRepository _employeeWriteRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IMapper mapper)
    {
        _employeeReadRepository = employeeReadRepository;
        _employeeWriteRepository = employeeWriteRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(e => e.Id == request.Id);
        _mapper.Map(request, employee);
        if (employee is not null)
        {
            _employeeWriteRepository.Update(employee);
            await _employeeWriteRepository.SaveChangeAsync();
        }
    }
}