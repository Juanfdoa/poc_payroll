using Microsoft.EntityFrameworkCore;
using Payroll.Core.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Payroll.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IdentityDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(IdentityDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
        {
            await _dbSet.AddRangeAsync(entities, ct);
            await _context.SaveChangesAsync(ct);
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.AnyAsync(predicate, ct);
        }

        public async Task DeleteAsync(T entity, CancellationToken ct = default)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync(ct);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(predicate, ct);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync(ct);
        }
    }
}