using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Responses.Commands;

public record AddResponseCommand : IRequest<Guid>
{
    public Guid ResponseId { get; set; } = Guid.NewGuid();
    public string Message { get; set; } = string.Empty;
    public Guid TicketId { get; set; }
    public Guid ResponderId { get; set; }
}

internal sealed class AddResponseCommandHandler : IRequestHandler<AddResponseCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddResponseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Response
        {
            ResponseId = request.ResponseId,
            Message = request.Message,
            TicketId = request.TicketId,
            ResponderId = request.ResponderId
        };

        await _unitOfWork.Responses.AddAsync(response);
        await _unitOfWork.CompleteAsync();

        return response.ResponseId;
    }
}