using AutoMapper;
using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Application.Utilities.Responses;
using EmployeeManagement.Domain.Entities.Concretes;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryHandler: IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesQueryHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
    {
        _mapper = mapper;
        _employeeReadRepository = employeeReadRepository;
    }

    public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Employee> employees;

            if (request.CompanyId.HasValue && request.DepartmentId.HasValue)
            {
                employees = await _employeeReadRepository.GetAllAsync(d =>
                    d.DepartmentId == request.DepartmentId && d.Department.CompanyId == request.CompanyId);
            }
            else if (request.CompanyId.HasValue)
            {
                employees = await _employeeReadRepository.GetAllAsync(d => d.Department.CompanyId == request.CompanyId);
            }
            else if (request.DepartmentId.HasValue)
            {
                employees = await _employeeReadRepository.GetAllAsync(d => d.DepartmentId == request.DepartmentId);
            }
            else
            {
                employees = await _employeeReadRepository.GetAllAsync();
            }

            var totalCount = employees.Count();
            var employeesForPage = employees
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var employeeDtos = _mapper.Map<ICollection<EmployeeDto>>(employeesForPage);

            return new GetAllEmployeesQueryResponse(
                employeeDtos, 
                totalCount, 
                request.PageSize, 
                request.Page);

    }

}