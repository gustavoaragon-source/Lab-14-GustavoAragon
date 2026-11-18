using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Responses.Querys;

public record GetResponsesByTicketQuery(Guid TicketId) : IRequest<IEnumerable<Response>>;

internal sealed class GetResponsesByTicketQueryHandler : IRequestHandler<GetResponsesByTicketQuery, IEnumerable<Response>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetResponsesByTicketQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Response>> Handle(GetResponsesByTicketQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.Responses.GetByTicketIdAsync(request.TicketId);
}