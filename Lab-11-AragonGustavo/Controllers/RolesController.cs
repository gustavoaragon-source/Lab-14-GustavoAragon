using Lab_11_AragonGustavo.Application.UseCases.Roles.Commands;
using Lab_11_AragonGustavo.Application.UseCases.Roles.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_AragonGustavo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRoleCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}