using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandHandler: IRequestHandler<UpdateDepartmentCommandRequest, IDataResult<int>>
{
    private readonly IDepartmentReadRepository _departmentReadRepository;
    private readonly IDepartmentWriteRepository _departmentWriteRepository;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommandHandler(IDepartmentReadRepository departmentReadRepository, IDepartmentWriteRepository departmentWriteRepository, IMapper mapper)
    {
        _departmentReadRepository = departmentReadRepository;
        _departmentWriteRepository = departmentWriteRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<int>> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(c => c.Id == request.Id);
        
        if (department == null)
        {
            return new ErrorDataResult<int>(0, "Department not found.");
        }

        _mapper.Map(request, department);
        _departmentWriteRepository.Update(department);
        await _departmentWriteRepository.SaveChangeAsync();

        return new SuccessDataResult<int>(department.Id, "Department updated successfully.");
    }
}