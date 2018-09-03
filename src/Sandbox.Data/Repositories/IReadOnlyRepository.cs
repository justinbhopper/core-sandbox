using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Data
{
	public interface IReadOnlyRepository<TEntity, TKey>
		where TEntity : class, new()
	{
		Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
		Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
	}
}