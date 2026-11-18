using Lab_11_AragonGustavo.Domain.Entities;

namespace Lab_11_AragonGustavo.Domain.Repositories;

public interface IResponseRepository
{
    Task<Response?> GetByIdAsync(Guid id);
    Task<IEnumerable<Response>> GetByTicketIdAsync(Guid ticketId);
    Task AddAsync(Response response);
}