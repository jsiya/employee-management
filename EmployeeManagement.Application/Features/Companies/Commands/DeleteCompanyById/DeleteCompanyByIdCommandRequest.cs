using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;

public class DeleteCompanyByIdCommandRequest: IRequest<IDataResult<int>>
{
    public int Id { get; set; }
}