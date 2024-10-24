using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;

public class DeleteCompanyByIdCommandRequest: IRequest<int>
{
    public int Id { get; set; }
}