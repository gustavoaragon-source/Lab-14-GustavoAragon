using Lab_11_AragonGustavo.Application.UseCases.Users.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_AragonGustavo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var user = await _mediator.Send(query);
        return user is not null ? Ok(user) : Unauthorized();
    }
}