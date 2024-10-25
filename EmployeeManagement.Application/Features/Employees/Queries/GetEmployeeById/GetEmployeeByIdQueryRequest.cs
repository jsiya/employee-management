using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryRequest: IRequest<IDataResult<EmployeeDto>>
{
    public int Id { get; set; }
}