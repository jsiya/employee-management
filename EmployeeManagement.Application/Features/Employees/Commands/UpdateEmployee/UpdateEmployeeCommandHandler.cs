using AutoMapper;
using EmployeeManagement.Application.Interfaces.Repositories.Employee;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler: IRequestHandler<UpdateEmployeeCommandRequest, IDataResult<int>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;
    private readonly IEmployeeWriteRepository _employeeWriteRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IMapper mapper)
    {
        _employeeReadRepository = employeeReadRepository;
        _employeeWriteRepository = employeeWriteRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<int>> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeReadRepository.GetAsync(e => e.Id == request.Id);
        if (employee == null)
        {
            return new ErrorDataResult<int>(0, "Employee not found.");
        }

        _mapper.Map(request, employee);
        _employeeWriteRepository.Update(employee);
        await _employeeWriteRepository.SaveChangeAsync();
        return new SuccessDataResult<int>(employee.Id, "Employee updated successfully.");
    }
}