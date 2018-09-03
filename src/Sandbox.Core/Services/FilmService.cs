using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data;
using Sandbox.Data.Models;

namespace Sandbox.Core.Services
{
	public class FilmService : BasicService<Film, long>, IFilmService
	{
		private readonly IRepository<Film, long> _repository;

		public FilmService(IRepository<Film, long> repository)
			: base(repository)
		{
			_repository = repository;
		}
		
		public Task<IList<Film>> GetManyAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}

		public Task DeleteManyByIdsAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}
	}
}