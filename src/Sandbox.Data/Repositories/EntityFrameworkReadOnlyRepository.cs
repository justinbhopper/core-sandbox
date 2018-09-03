using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sandbox.Data
{
	public class EntityFrameworkReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
		where TEntity : class, new()
	{
		private readonly DbSet<TEntity> _dbSet;

		public EntityFrameworkReadOnlyRepository(DbSet<TEntity> dbSet)
		{
			_dbSet = dbSet;
		}
		
		public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _dbSet.ToListAsync(cancellationToken).ConfigureAwait(false);
		}

		public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _dbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
		}
	}
}