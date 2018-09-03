using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Data;
using Sandbox.Data.Models;

namespace Sandbox.Core.Services
{
	public interface IFilmService : IBasicService<Film, long>
	{
		Task<IList<Film>> GetManyAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken));
		Task DeleteManyByIdsAsync(IEnumerable<long> filmIds, CancellationToken cancellationToken = default(CancellationToken));
	}
}