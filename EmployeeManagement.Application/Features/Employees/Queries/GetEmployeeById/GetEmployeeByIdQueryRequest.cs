using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryRequest: IRequest<GetEmployeeByIdQueryResponse>
{
    public int Id { get; set; }
}