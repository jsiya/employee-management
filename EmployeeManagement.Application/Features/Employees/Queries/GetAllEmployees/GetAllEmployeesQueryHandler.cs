using AutoMapper;
using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
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
        if ((request.CompanyId is not null) && (request.DepartmentId is not null))
        {
            employees = await _employeeReadRepository.GetAllAsync(d =>
                d.DepartmentId == request.DepartmentId && d.Department.CompanyId == request.CompanyId);
        }
        else if (request.CompanyId is not null)
        {
            employees = await _employeeReadRepository.GetAllAsync(d => d.Department.CompanyId == request.CompanyId);
        }
        else if (request.DepartmentId is not null)
        {
            employees = await _employeeReadRepository.GetAllAsync(d => d.DepartmentId == request.DepartmentId);
        }
        else
        {
            employees = await _employeeReadRepository.GetAllAsync();
        }
        var employeesForPage = employees.ToList()
            .Skip((request.Page-1) * request.PageSize)
            .Take(request.PageSize).ToList();
        return new GetAllEmployeesQueryResponse()
        {
            Employee = _mapper.Map<ICollection<EmployeeDto>>(employeesForPage)
        };
    }
}