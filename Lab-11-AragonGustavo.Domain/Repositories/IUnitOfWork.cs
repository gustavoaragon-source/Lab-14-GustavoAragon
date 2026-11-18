namespace Lab_11_AragonGustavo.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IResponseRepository Responses { get; }
    IRoleRepository Roles { get; }
    ITicketRepository Tickets { get; }
    IUserRepository Users { get; }
    IUserRoleRepository UserRoles { get; }
    Task<int> CompleteAsync();
}