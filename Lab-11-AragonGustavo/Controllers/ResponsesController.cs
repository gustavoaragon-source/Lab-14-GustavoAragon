using Lab_11_AragonGustavo.Application.UseCases.Responses.Commands;
using Lab_11_AragonGustavo.Application.UseCases.Responses.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_11_AragonGustavo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("ticket/{ticketId:guid}")]
    public async Task<IActionResult> GetByTicket(Guid ticketId)
    {
        var responses = await _mediator.Send(new GetResponsesByTicketQuery(ticketId));
        return Ok(responses);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddResponseCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}