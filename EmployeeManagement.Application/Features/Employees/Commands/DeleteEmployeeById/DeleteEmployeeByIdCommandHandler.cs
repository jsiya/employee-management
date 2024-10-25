using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;

public class DeleteEmployeeByIdCommandHandler: IRequestHandler<DeleteEmployeeByIdCommandRequest, IDataResult<int>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IEmployeeWriteRepository _employeeWriteRepository;

    public DeleteEmployeeByIdCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
    {
        _employeeReadRepository = employeeReadRepository;
        _employeeWriteRepository = employeeWriteRepository;
    }

    public async Task<IDataResult<int>> Handle(DeleteEmployeeByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(c => c.Id == request.Id);
        
        if (employee == null)
        {
            return new ErrorDataResult<int>(0, "Employee not found.");
        }

        _employeeWriteRepository.Remove(employee);
        await _employeeWriteRepository.SaveChangeAsync();

        return new SuccessDataResult<int>(employee.Id, "Employee deleted successfully.");
    }
}