using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.UserRoles.Commands;

public record AddUserRoleCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}

internal sealed class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        await _unitOfWork.UserRoles.AddAsync(userRole);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}