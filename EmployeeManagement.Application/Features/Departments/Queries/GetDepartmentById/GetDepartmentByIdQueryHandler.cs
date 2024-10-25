using AutoMapper;
using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQueryRequest, IDataResult<DepartmentDto>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadRepository _departmentReadRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentReadRepository departmentReadRepository, IMapper mapper)
    {
        _departmentReadRepository = departmentReadRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<DepartmentDto>> Handle(GetDepartmentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(d => d.Id == request.Id);

        if (department == null)
        {
            return new ErrorDataResult<DepartmentDto>(null, "Department not found.");
        }

        var departmentDto = _mapper.Map<DepartmentDto>(department);
        return new SuccessDataResult<DepartmentDto>(departmentDto, "Department retrieved successfully.");
    }
}