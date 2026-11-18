using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Tickets.Querys;

public record GetAllTicketsQuery : IRequest<IEnumerable<Ticket>>;

internal sealed class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<Ticket>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Tickets.GetAllAsync();
    }
}