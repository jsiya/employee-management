using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartmentById;

public class DeleteDepartmentByIdCommandHandler: IRequestHandler<DeleteDepartmentByIdCommandRequest,  IDataResult<int>>
{
    private readonly IDepartmentReadRepository _departmentReadRepository;
    private readonly IDepartmentWriteRepository _departmentWriteRepository;

    public DeleteDepartmentByIdCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository)
    {
        _departmentWriteRepository = departmentWriteRepository;
        _departmentReadRepository = departmentReadRepository;
    }

    public async Task<IDataResult<int>> Handle(DeleteDepartmentByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(c => c.Id == request.Id);
        
        if (department == null)
        {
            return new ErrorDataResult<int>(0, "Department not found.");
        }

        _departmentWriteRepository.Remove(department);
        await _departmentWriteRepository.SaveChangeAsync();

        return new SuccessDataResult<int>(department.Id, "Department deleted successfully.");
    }
}