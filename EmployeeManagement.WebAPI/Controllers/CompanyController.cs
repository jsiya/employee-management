using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;
using EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;
using EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;
using EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;
using EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers;

[ApiController]
[Route("api")]
public class CompanyController: ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("companies")]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommandRequest commandRequest)
    {
        var companyId = await _mediator.Send(commandRequest);
        return Ok();
    }
    
    [HttpGet("companies")]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllCompaniesQueryRequest
        {
            Page = page,
            PageSize = pageSize
        };
        var companies = await _mediator.Send(query);
        return Ok(companies);
    }
    
    [HttpGet("companies/{id:int}")]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies(int id)
    {
        var query = new GetCompanyByIdQueryRequest()
        {
            Id = id
        };
        var company = await _mediator.Send(query);
        return Ok(company);
    }
    
    [HttpPut("companies/{id:int}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyCommandRequest command)
    {
        if (id != command.Id)
        {
            return BadRequest("Mismatched Company ID");
        }

        await _mediator.Send(command);
        return NoContent(); 
    }
    
    [HttpDelete("companies/{id:int}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _mediator.Send(new DeleteCompanyByIdCommandRequest() { Id = id });
        return NoContent();
    }
    
}