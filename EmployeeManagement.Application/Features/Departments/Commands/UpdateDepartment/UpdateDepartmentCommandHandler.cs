using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandHandler: IRequestHandler<UpdateDepartmentCommandRequest>
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

    public async Task Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(c => c.Id == request.Id);
        _mapper.Map(request, department);
        if (department is not null)
        {
            _departmentWriteRepository.Update(department);
            await _departmentWriteRepository.SaveChangeAsync();
        }
    }
}