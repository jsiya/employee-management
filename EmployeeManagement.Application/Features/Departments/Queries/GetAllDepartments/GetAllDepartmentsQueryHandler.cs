using AutoMapper;
using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Department;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQueryHandler: IRequestHandler<GetAllDepartmentsQueryRequest, GetAllDepartmentsQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadRepository _departmentReadRepository;

    public GetAllDepartmentsQueryHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository)
    {
        _mapper = mapper;
        _departmentReadRepository = departmentReadRepository;
    }

    public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Department> departments;

        if (request.CompanyId is not null)
        {
            departments = await _departmentReadRepository.GetAllAsync(d => d.CompanyId == request.CompanyId);
        }
        else
        {
            departments = await _departmentReadRepository.GetAllAsync();
        }

        var totalCount = departments.Count();
        var departmentsForPage = departments
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var departmentDtos = _mapper.Map<ICollection<DepartmentDto>>(departmentsForPage);

        return new GetAllDepartmentsQueryResponse(
            departmentDtos,
            totalCount,
            request.PageSize,
            request.Page
        );
    }
}