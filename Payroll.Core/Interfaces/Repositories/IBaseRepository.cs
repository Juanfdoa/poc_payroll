using System.Linq.Expressions;

namespace Payroll.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
        Task DeleteAsync(T entity, CancellationToken ct = default);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    }
}