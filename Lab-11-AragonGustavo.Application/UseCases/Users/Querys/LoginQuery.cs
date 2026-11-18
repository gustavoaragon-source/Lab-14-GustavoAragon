using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using MediatR;

namespace Lab_11_AragonGustavo.Application.UseCases.Users.Querys;

public record LoginQuery : IRequest<User?>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

internal sealed class LoginQueryHandler : IRequestHandler<LoginQuery, User?>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
        if (user != null && user.PasswordHash == request.Password)
        {
            return user;
        }
        return null;
    }
}