using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers;

[ApiController]
[Route("api")]
public class EmployeeController: ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("employees")]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
    
    [HttpGet("employees")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        return Ok();
    }
    
    [HttpGet("employees/{id:int}")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployeeById(int id)
    {
        var query = new GetEmployeeByIdQueryRequest()
        {
            Id = id
        };
        var employee = await _mediator.Send(query);
        return Ok(employee);
    }
    
    [HttpPut("employees/{id:int}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateEmployeeCommandRequest command)
    {
        if (id != command.Id)
        {
            return BadRequest("Mismatched Department ID");
        }

        await _mediator.Send(command);
        return NoContent(); 
    }
    
    [HttpDelete("employees/{id:int}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _mediator.Send(new DeleteEmployeeByIdCommandRequest() { Id = id });
        return NoContent();
    }
}