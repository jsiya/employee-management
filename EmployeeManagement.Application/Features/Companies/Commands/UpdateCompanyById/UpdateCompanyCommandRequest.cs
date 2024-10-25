using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;

public class UpdateCompanyCommandRequest: IRequest<int>
{
    [FromRoute]
    public int Id { get; set; }
    public string Name { get; set; }
}