using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
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
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommandRequest commandRequest)
    {
        return Ok();
    }
    
    [HttpGet("employees")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        return Ok();
    }
    
    [HttpGet("employees/{id:int}")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees(int id)
    {
        return Ok();
    }
    
    [HttpPut("employees/{id:int}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateEmployeeCommandRequest command)
    {
        return NoContent(); 
    }
    
    [HttpDelete("employees/{id:int}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        return NoContent();
    }
}