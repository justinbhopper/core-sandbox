using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sandbox.Data
{
	public class EntityFrameworkRepository<TEntity, TKey> : EntityFrameworkReadOnlyRepository<TEntity, TKey>, IRepository<TEntity, TKey>
		where TEntity : class, new()
	{
		private readonly DbContext _context;

		public EntityFrameworkRepository(DbContext context)
			: base(context.Set<TEntity>())
		{
			_context = context;
		}
		
		public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entry = _context.Add(entity);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			return entry.Entity;
		}

		public async Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.AddRange(entities);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}

		public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			// TODO: throw ResourceNotFoundException

			_context.Update(entity);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}

		public async Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.UpdateRange(entities);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}

		public async Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
		{
			// TODO: throw ResourceNotFoundException
			
			var entity = await GetAsync(id, cancellationToken).ConfigureAwait(false);
			await DeleteAsync(entity, cancellationToken).ConfigureAwait(false);
		}

		public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			// TODO: throw ResourceNotFoundException
			
			_context.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}

		public async Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.RemoveRange(entities);
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}
	}
}