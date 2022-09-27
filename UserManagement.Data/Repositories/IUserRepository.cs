using UserManagement.Domain;

namespace UserManagement.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(Guid id, CancellationToken ct = default);
        void CreateUser(User user);
    }
}
