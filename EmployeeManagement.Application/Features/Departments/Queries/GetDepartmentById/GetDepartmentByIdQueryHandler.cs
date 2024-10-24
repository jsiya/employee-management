using AutoMapper;
using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryHandler: IRequestHandler<GetDepartmentByIdQueryRequest, GetDepartmentByIdQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadRepository _departmentReadRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentReadRepository departmentReadRepository, IMapper mapper)
    {
        _departmentReadRepository = departmentReadRepository;
        _mapper = mapper;
    }


    public async Task<GetDepartmentByIdQueryResponse> Handle(GetDepartmentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadRepository.GetAsync(d => d.Id == request.Id);
        return new GetDepartmentByIdQueryResponse()
        {
            Departments = _mapper.Map<DepartmentDto>(department)
        };
    }
}