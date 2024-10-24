using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;

public class UpdateCompanyCommandRequest: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}