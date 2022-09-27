using Microsoft.EntityFrameworkCore;
using UserManagement.Domain;

namespace UserManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
