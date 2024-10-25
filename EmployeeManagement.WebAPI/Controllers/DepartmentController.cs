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
        var result = await _mediator.Send(request);
        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return CreatedAtAction(nameof(GetDepartmentById), new { id = result.Data }, new { message = "Department created successfully." });
    }
    
    
    [HttpGet("departments/{id:int}")]
    public async Task<ActionResult<List<DepartmentDto>>> GetDepartmentById(int id)
    {
        var query = new GetDepartmentByIdQueryRequest { Id = id };
        var result = await _mediator.Send(query);
        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(result);
    }
    
    [HttpGet("departments")]
    public async Task<ActionResult<List<DepartmentDto>>> GetDepartments([FromQuery] GetAllDepartmentsQueryRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(result);
    }
    
    [HttpPut("departments/{id:int}")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentCommandRequest command)
    {
        if (id != command.Id)
        {
            return BadRequest("Mismatched Department ID");
        }

        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(new { message = "Department updated successfully.", departmentId = result.Data });
    }
    
    [HttpDelete("departments/{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var result = await _mediator.Send(new DeleteDepartmentByIdCommandRequest { Id = id });

        if (!result.Success)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(new { message = "Department deleted successfully.", departmentId = result.Data });
    }

}