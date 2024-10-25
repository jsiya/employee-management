using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployeeById;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;
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
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return CreatedAtAction(nameof(GetEmployeeById), new { id = result.Data }, new { message = "Employee created successfully." });
    }

    
    [HttpGet("employees")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees([FromQuery] GetAllEmployeesQueryRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }
        return Ok(result);
    }
    
    [HttpGet("employees/{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var query = new GetEmployeeByIdQueryRequest { Id = id };
        var result = await _mediator.Send(query);
        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(result.Data);
    }
    
    [HttpPut("employees/{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeCommandRequest command)
    {
        if (id != command.Id) {
            return BadRequest("Mismatched Employee ID");
        }

        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(new { message = "Employee updated successfully.", employeeId = result.Data });
    }

    
    [HttpDelete("employees/{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var result = await _mediator.Send(new DeleteEmployeeByIdCommandRequest { Id = id });
        if (!result.Success){
            return NotFound(new { message = result.Message });
        }
        
        return Ok(new { message = "Employee deleted successfully.", employeeId = result.Data });
    }

}