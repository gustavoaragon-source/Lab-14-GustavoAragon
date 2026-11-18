using Lab_11_AragonGustavo.Application.UseCases.Tickets.Commands;
using Lab_11_AragonGustavo.Application.UseCases.Tickets.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_AragonGustavo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddTicketCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}