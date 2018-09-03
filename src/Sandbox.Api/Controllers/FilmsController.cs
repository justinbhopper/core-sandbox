using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Data;
using Sandbox.Data.Models;
using Sandbox.Core.Services;

namespace Sandbox.Controllers
{
	[ApiController]
	[Route("api/v1/films")]
	public class FilmsController : ControllerBase
	{
		private readonly IFilmService _filmsService;

		public FilmsController(IFilmService filmsService)
		{
			_filmsService = filmsService;
		}

		// GET api/v1/films
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IList<Film>))]
		public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
		{
			return Ok(await _filmsService.GetAllAsync(cancellationToken));
		}

		// GET api/v1/films/5
		[HttpGet("{id}", Name = "GetFilm")]
		[ProducesResponseType(200, Type = typeof(Film))]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
		{
			var film = await _filmsService.GetAsync(id, cancellationToken);
			if (film == null)
				return NotFound();
			return Ok(film);
		}

		// POST api/v1/films
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Film))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> InsertAsync([FromBody] Film film, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (film == null)
				return BadRequest();

			film = await _filmsService.AddAsync(film, cancellationToken);

			return CreatedAtRoute("GetFilm", new { id = film.Id }, film);
		}

		// PUT api/v1/films/5
		[HttpPut("{id}")]
		[ProducesResponseType(200, Type = typeof(Film))]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateAsync(long id, [FromBody] Film film, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (film == null)
				return BadRequest();

			film.Id = id;

			try
			{
				await _filmsService.UpdateAsync(film, cancellationToken);
			}
			catch (ResourceNotFoundException)
			{
				return NotFound();
			}

			return await GetByIdAsync(id, cancellationToken);
		}

		// DELETE api/v1/films/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var existing = await _filmsService.GetAsync(id, cancellationToken);
			if (existing == null)
				return NotFound();

			try
			{
				await _filmsService.DeleteAsync(existing, cancellationToken);
			}
			catch (ResourceNotFoundException)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
