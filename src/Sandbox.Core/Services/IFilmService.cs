using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Core.Models;

namespace Sandbox.Core.Services
{
	public interface IFilmService
	{
		Task<IList<Film>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
		Task<Film> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
		Task<IList<Film>> GetManyAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken));
		Task<List<Film>> FindByTitleAsync(string title, CancellationToken cancellationToken = default(CancellationToken));
		Task<Film> AddAsync(Film entity, CancellationToken cancellationToken = default(CancellationToken));
		Task AddManyAsync(IEnumerable<Film> entities, CancellationToken cancellationToken = default(CancellationToken));
		Task<Film> UpdateAsync(Film entity, CancellationToken cancellationToken = default(CancellationToken));
		Task UpdateManyAsync(IEnumerable<Film> films, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteManyByIdsAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteAsync(Film film, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteManyAsync(IEnumerable<Film> films, CancellationToken cancellationToken = default(CancellationToken));
	}
}