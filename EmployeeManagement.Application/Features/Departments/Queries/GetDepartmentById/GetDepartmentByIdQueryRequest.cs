using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQueryRequest: IRequest<GetDepartmentByIdQueryResponse>
{
    public int Id { get; set; }
}