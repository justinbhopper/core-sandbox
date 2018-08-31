using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandbox.Core.Models;

namespace Sandbox.Core.Services
{
	public class FilmService : IFilmService
	{
		private readonly SandboxDbContext _context;

		public FilmService(SandboxDbContext context)
		{
			_context = context;
		}
		
		public async Task<IList<Film>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _context.Films.ToListAsync(cancellationToken);
		}

		public async Task<Film> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _context.FindAsync<Film>(id, cancellationToken);
		}

		public async Task<IList<Film>> GetManyAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken))
		{
			var ids = new HashSet<long>(filmIds);
			return await _context.Films
				.Where(f => ids.Contains(f.Id))
				.ToListAsync(cancellationToken);
		}

		public async Task<List<Film>> FindByTitleAsync(string title, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _context.Films
				.Where(f => string.Equals(f.Title, title, StringComparison.InvariantCultureIgnoreCase))
				.ToListAsync(cancellationToken);
		}

		public async Task<Film> AddAsync(Film film, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entry = _context.Add(film);
			await _context.SaveChangesAsync(cancellationToken);
			return entry.Entity;
		}

		public async Task AddManyAsync(IEnumerable<Film> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.AddRange(entities, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task<Film> UpdateAsync(Film film, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entry = _context.Update(film);
			await _context.SaveChangesAsync(cancellationToken);
			return entry.Entity;
		}

		public async Task UpdateManyAsync(IEnumerable<Film> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.UpdateRange(entities);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
		{
			var film = await GetByIdAsync(id, cancellationToken);
			_context.Films.Remove(film);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteManyByIdsAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken))
		{
			var films = await GetManyAsync(filmIds, cancellationToken);
			_context.Films.RemoveRange(films);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAsync(Film film, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.Remove(film);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteManyAsync(IEnumerable<Film> entities, CancellationToken cancellationToken = default(CancellationToken))
		{
			_context.RemoveRange(entities);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}