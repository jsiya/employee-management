using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;

public class DeleteEmployeeByIdCommandHandler: IRequestHandler<DeleteEmployeeByIdCommandRequest>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IEmployeeWriteRepository _employeeWriteRepository;

    public DeleteEmployeeByIdCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
    {
        _employeeReadRepository = employeeReadRepository;
        _employeeWriteRepository = employeeWriteRepository;
    }

    public async Task Handle(DeleteEmployeeByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(c => c.Id == request.Id);
        if (employee is not null)
        {
            _employeeWriteRepository.Remove(employee);
            await _employeeWriteRepository.SaveChangeAsync();
        }
    }
}