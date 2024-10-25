using EmployeeManagement.Application.Utilities.Responses;
using MediatR;

namespace EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandRequest: IRequest<IDataResult<int>>
{
    public string Name { get; set; }
}