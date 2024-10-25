using AutoMapper;
using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQueryRequest, IDataResult<EmployeeDto>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IMapper _mapper;
    public GetEmployeeByIdQueryHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
    {
        _mapper = mapper;
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<IDataResult<EmployeeDto>> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(e => e.Id == request.Id);

        if (employee == null)
        {
            return new ErrorDataResult<EmployeeDto>(null, "Employee not found.");
        }

        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return new SuccessDataResult<EmployeeDto>(employeeDto, "Employee retrieved successfully.");
    }
}