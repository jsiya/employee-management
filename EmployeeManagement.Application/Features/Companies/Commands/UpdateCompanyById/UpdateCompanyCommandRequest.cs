using EmployeeManagement.Application.Utilities.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;

public class UpdateCompanyCommandRequest: IRequest<IDataResult<int>>
{
    [FromRoute]
    public int Id { get; set; }
    public string Name { get; set; }
}