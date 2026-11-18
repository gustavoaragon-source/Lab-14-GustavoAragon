using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly ApplicationDbContext _context;

    public UserRoleRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<UserRole>> GetByUserIdAsync(Guid userId) => 
        await _context.UserRoles.Where(ur => ur.UserId == userId).ToListAsync();

    public async Task AddAsync(UserRole userRole) => 
        await _context.UserRoles.AddAsync(userRole);
}