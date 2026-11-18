using Lab_11_AragonGustavo.Domain.Entities;

namespace Lab_11_AragonGustavo.Domain.Repositories;

public interface IUserRoleRepository
{
    Task<IEnumerable<UserRole>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserRole userRole);
}