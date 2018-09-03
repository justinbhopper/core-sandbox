using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sandbox.Core.Services
{
	public interface IBasicService<TEntity, TKey>
		where TEntity : class, new()
	{
		Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
		Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
		Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
		Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
	}
}