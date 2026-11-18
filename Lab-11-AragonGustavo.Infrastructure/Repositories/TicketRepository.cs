using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Ticket>> GetAllAsync() => 
        await _context.Tickets.ToListAsync();

    public async Task<Ticket?> GetByIdAsync(Guid id) => 
        await _context.Tickets.FindAsync(id);

    public async Task AddAsync(Ticket ticket) => 
        await _context.Tickets.AddAsync(ticket);
}