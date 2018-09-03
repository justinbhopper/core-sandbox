using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data;

namespace Sandbox.Core.Services
{
	public class BasicService<TEntity, TKey>
		where TEntity : class, new()
	{
		private readonly IRepository<TEntity, TKey> _repository;

		public BasicService(IRepository<TEntity, TKey> repository)
		{
			_repository = repository;
		}
		
		public Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.GetAllAsync(cancellationToken);
		}

		public Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.GetAsync(id, cancellationToken);
		}

		public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.AddAsync(entity, cancellationToken);
		}

		public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.AddManyAsync(entities, cancellationToken);
		}

		public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.UpdateAsync(entity, cancellationToken);
		}

		public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.UpdateManyAsync(entities, cancellationToken);
		}

		public Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.DeleteByIdAsync(id, cancellationToken);
		}

		public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.DeleteAsync(entity, cancellationToken);
		}

		public Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			return _repository.DeleteManyAsync(entities, cancellationToken);
		}
	}
}