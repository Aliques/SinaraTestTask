using Microsoft.EntityFrameworkCore;
using UserManagement.Common.Wrapper;
using UserManagement.Domain;
using UserManagement.Infrastructure.Data;

namespace UserManagement.Infrastructure.Repositories
{
    /// <summary>
    /// TODO: по идее выносится в core-сборку
    /// </summary>
    /// <typeparam name="TEntityId">The Entity identificator type</typeparam>
    public class BaseRepository<TEntityId>
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        protected virtual async Task<IResult<TEntity>> AddAsync<TEntity>(TEntity entity,
                CancellationToken ct = default)
            where TEntity : class, IEntity<TEntityId>
        {
            return await ToResultAsync(async () =>
            {
                _context.Set<TEntity>().Add(entity);
                var result = await _context.SaveChangesAsync(ct);
                return entity;
            });
        }

        protected virtual async Task<IResult> UpdateAsync<TEntity>(TEntity entity,
                CancellationToken ct)
            where TEntity : class, IEntity<TEntityId>
        {
            return await ToResultAsync(async () =>
            {
               _context.Entry(entity).CurrentValues.SetValues(entity);
               _context.Entry(entity).State = EntityState.Modified;
               await _context.SaveChangesAsync(ct);
            });
        }

        protected virtual async Task<IResult<TEntity>> GetByIdAsync<TEntity, TId>(TEntityId id,
            CancellationToken ct) where TEntity : class, IEntity<TEntityId>
        {

            return await ToResultAsync(async () =>
            {
                return await _context.Set<TEntity>().FirstAsync(i => i.Id.Equals(id), ct);
            });
        }

        protected async Task<IResult<T>> ToResultAsync<T>(Func<Task<T>> func)
                => await Result<T>.ExecuteAsync(func);
        protected async Task<IResult> ToResultAsync(Func<Task> func) => await Result.ExecuteAsync(func);

    }
}
