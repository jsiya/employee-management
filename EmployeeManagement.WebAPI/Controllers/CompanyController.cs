using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;
using EmployeeManagement.Application.Features.Companies.Commands.DeleteCompanyById;
using EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;
using EmployeeManagement.Application.Features.Companies.Queries.GetAllCompanies;
using EmployeeManagement.Application.Features.Companies.Queries.GetCompanyById;
using EmployeeManagement.Application.Utilities.Responses;
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
        var result = await _mediator.Send(commandRequest);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(new { companyId = result.Data, message = result.Message });
    }
    
    [HttpGet("companies")]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllCompaniesQueryRequest
        {
            Page = page,
            PageSize = pageSize
        };
        var result = await _mediator.Send(query);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
    
    [HttpGet("companies/{id:int}")]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanyById(int id)
    {
        var result = await _mediator.Send(new GetCompanyByIdQueryRequest { Id = id });

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
    
    [HttpPut("companies/{id:int}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyCommandRequest command)
    {
        if (id != command.Id)
        {
            return BadRequest(new { message = "Mismatched Company ID" });
        }

        var result = await _mediator.Send(command) as IDataResult<int>;

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(new { message = "Company updated successfully", companyId = result.Data });
    }
    
    [HttpDelete("companies/{id:int}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var result = await _mediator.Send(new DeleteCompanyByIdCommandRequest { Id = id });

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(new { message = result.Message });
    }
    
}