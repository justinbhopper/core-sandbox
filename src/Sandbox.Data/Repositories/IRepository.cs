using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Data
{
	public interface IRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
		where TEntity : class, new()
	{
		Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
		Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
	}
}