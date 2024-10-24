using AutoMapper;
using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQueryRequest, GetEmployeeByIdQueryResponse>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IMapper _mapper;
    public GetEmployeeByIdQueryHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository)
    {
        _mapper = mapper;
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(e => e.Id == request.Id);

        return new GetEmployeeByIdQueryResponse()
        {
            Employee = _mapper.Map<EmployeeDto>(employee)
        };
    }
}