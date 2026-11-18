using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IResponseRepository Responses { get; }
    public IRoleRepository Roles { get; }
    public ITicketRepository Tickets { get; }
    public IUserRepository Users { get; }
    public IUserRoleRepository UserRoles { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IResponseRepository responses,
        IRoleRepository roles,
        ITicketRepository tickets,
        IUserRepository users,
        IUserRoleRepository userRoles)
    {
        _context = context;
        Responses = responses;
        Roles = roles;
        Tickets = tickets;
        Users = users;
        UserRoles = userRoles;
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}