using Lab_11_AragonGustavo.Domain.Entities;

namespace Lab_11_AragonGustavo.Domain.Repositories;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(Guid id);
    Task AddAsync(Role role);
}