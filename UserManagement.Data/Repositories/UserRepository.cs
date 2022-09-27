using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Interfaces.Repositories;
using UserManagement.Common.Enums;
using UserManagement.Common.Wrapper;
using UserManagement.Domain;
using UserManagement.Infrastructure.Data;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<Guid>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IResult<User>> CreateAsync(User user, CancellationToken ct = default)
        {
            return await base.AddAsync(user, ct);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Where(u=>u.UserStatus == UserStatus.Active)
                .ToListAsync();
        }

        public async Task<IResult<User>> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await base.GetByIdAsync<User, Guid>(id, ct);
        }
        public async Task<IResult> UpdateAsync(User entity, CancellationToken ct = default)
        {
            return await base.UpdateAsync(entity, ct);
        }
    }
}
