using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<User>> GetAllAsync() => 
        await _context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id) => 
        await _context.Users.FindAsync(id);

    public async Task<User?> GetByEmailAsync(string email) => 
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user) => 
        await _context.Users.AddAsync(user);
}