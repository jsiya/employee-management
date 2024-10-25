using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartmentById;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;
using EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;
using EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers;

[ApiController]
[Route("api")]
public class DepartmentController: ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("departments")]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommandRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpGet("departments/{id:int}")]
    public async Task<ActionResult<List<DepartmentDto>>> GetDepartmentById(int id)
    {
        var query = new GetDepartmentByIdQueryRequest()
        {
            Id = id
        };
        var department = await _mediator.Send(query);
        return Ok(department);
    }
    
    [HttpGet("departments")]
    public async Task<ActionResult<List<DepartmentDto>>> GetDepartments([FromQuery] GetAllDepartmentsQueryRequest request)
    {
        var departments = await _mediator.Send(request);
        return Ok(departments);
    }
    
    [HttpPut("departments/{id:int}")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentCommandRequest command)
    {
        if (id != command.Id)
        {
            return BadRequest("Mismatched Department ID");
        }

        await _mediator.Send(command);
        return NoContent(); 
    }
    
    [HttpDelete("departments/{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _mediator.Send(new DeleteDepartmentByIdCommandRequest() { Id = id });
        return NoContent();
    }
}