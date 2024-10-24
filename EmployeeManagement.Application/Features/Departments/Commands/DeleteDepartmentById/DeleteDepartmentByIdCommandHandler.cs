using EmployeeManagement.Application.Interfaces.Repositories.Department;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartmentById;

public class DeleteDepartmentByIdCommandHandler: IRequestHandler<DeleteDepartmentByIdCommandRequest>
{
    private readonly IDepartmentReadRepository _departmentReadRepository;
    private readonly IDepartmentWriteRepository _departmentWriteRepository;

    public DeleteDepartmentByIdCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository)
    {
        _departmentWriteRepository = departmentWriteRepository;
        _departmentReadRepository = departmentReadRepository;
    }

    public async Task Handle(DeleteDepartmentByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(c => c.Id == request.Id);
        if (department is not null)
        {
            _departmentWriteRepository.Remove(department);
            await _departmentWriteRepository.SaveChangeAsync();
        }
    }
}