using UserManagement.Common.Wrapper;
using UserManagement.Domain;

namespace UserManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<IResult<User>> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IResult<User>> CreateAsync(User user, CancellationToken ct = default);
        Task<IResult> UpdateAsync(User entity, CancellationToken ct = default);
    }
}
