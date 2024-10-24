using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandRequest: IRequest<int>
{
    public string Name { get; set; }
}