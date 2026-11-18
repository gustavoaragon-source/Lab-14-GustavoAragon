using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.UserRoles.Querys;

public record GetRolesByUserQuery(Guid UserId) : IRequest<IEnumerable<UserRole>>;

internal sealed class GetRolesByUserQueryHandler : IRequestHandler<GetRolesByUserQuery, IEnumerable<UserRole>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRolesByUserQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<UserRole>> Handle(GetRolesByUserQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.UserRoles.GetByUserIdAsync(request.UserId);
}