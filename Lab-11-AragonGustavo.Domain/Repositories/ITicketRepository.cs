using Lab_11_AragonGustavo.Domain.Entities;

namespace Lab_11_AragonGustavo.Domain.Repositories;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(Guid id);
    Task AddAsync(Ticket ticket);
}