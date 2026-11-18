using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Role>> GetAllAsync() => 
        await _context.Roles.ToListAsync();

    public async Task<Role?> GetByIdAsync(Guid id) => 
        await _context.Roles.FindAsync(id);

    public async Task AddAsync(Role role) => 
        await _context.Roles.AddAsync(role);
}