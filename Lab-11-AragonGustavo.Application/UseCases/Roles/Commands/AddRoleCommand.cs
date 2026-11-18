using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Roles.Commands;

public record AddRoleCommand : IRequest<Guid>
{
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string RoleName { get; set; } = string.Empty;
}

internal sealed class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            RoleId = request.RoleId,
            RoleName = request.RoleName
        };

        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.CompleteAsync();

        return role.RoleId;
    }
}