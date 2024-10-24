using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler: IRequestHandler<CreateDepartmentCommandRequest>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentWriteRepository _departmentWriteRepository;

    public CreateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IMapper mapper)
    {
        _departmentWriteRepository = departmentWriteRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        await _departmentWriteRepository.AddAsync(department);
        await _departmentWriteRepository.SaveChangeAsync();
    }
}