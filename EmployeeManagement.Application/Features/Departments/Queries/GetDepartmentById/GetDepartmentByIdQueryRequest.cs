using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryRequest: IRequest<IDataResult<DepartmentDto>>
{
    public int Id { get; set; }
}