using Lab_11_AragonGustavo.Domain.Entities;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab_11_AragonGustavo.Infrastructure.Repositories;

public class ResponseRepository : IResponseRepository
{
    private readonly ApplicationDbContext _context;

    public ResponseRepository(ApplicationDbContext context) => _context = context;

    public async Task<Response?> GetByIdAsync(Guid id) => 
        await _context.Responses.FindAsync(id);

    public async Task<IEnumerable<Response>> GetByTicketIdAsync(Guid ticketId) => 
        await _context.Responses.Where(r => r.TicketId == ticketId).ToListAsync();

    public async Task AddAsync(Response response) => 
        await _context.Responses.AddAsync(response);
}