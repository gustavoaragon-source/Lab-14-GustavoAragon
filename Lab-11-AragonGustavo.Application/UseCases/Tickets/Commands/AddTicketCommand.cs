using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Tickets.Commands;

public record AddTicketCommand : IRequest<Guid>
{
    public Guid TicketId { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}

internal sealed class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            TicketId = request.TicketId,
            Title = request.Title,
            Description = request.Description,
            UserId = request.UserId
        };

        await _unitOfWork.Tickets.AddAsync(ticket);
        await _unitOfWork.CompleteAsync();

        return ticket.TicketId;
    }
}