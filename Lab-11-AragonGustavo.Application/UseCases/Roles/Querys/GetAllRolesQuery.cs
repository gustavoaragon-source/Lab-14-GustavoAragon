using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Roles.Querys;

public record GetAllRolesQuery() : IRequest<IEnumerable<Role>>;

internal sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.Roles.GetAllAsync();
}