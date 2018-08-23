using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sandbox.Models;

namespace Sandbox.Controllers
{
	[ApiController]
	[Route("api/v1/films")]
	public class FilmsController : ControllerBase
	{
		private readonly SandboxDbContext _context;

		public FilmsController(SandboxDbContext context)
		{
			_context = context;

			if (_context.Films.Count() == 0)
			{
				_context.Films.Add(new Film { Title = "Back to the Future", Year = 1985, Rank = 1 });
				_context.SaveChanges();
			}
		}

		// GET api/v1/films
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Film>))]
		public async Task<ActionResult<IEnumerable<Film>>> GetAllAsync()
		{
			return Ok(await _context.Films.ToListAsync());
		}

		// GET api/v1/films/5
		[HttpGet("{id}", Name = "GetFilm")]
		[ProducesResponseType(200, Type = typeof(Film))]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Film>> GetByIdAsync(long id)
		{
			var film = await _context.Films.FindAsync(id);
			if (film == null)
				return NotFound();
			return Ok(film);
		}

		// POST api/v1/films
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Film))]
		[ProducesResponseType(400)]
		public async Task<ActionResult<Film>> PostAsync([FromBody] Film film)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _context.Films.AddAsync(film);
			await _context.SaveChangesAsync();

			return CreatedAtRoute("GetFilm", new { id = film.Id }, film);
		}

		// PUT api/v1/films/5
		[HttpPut("{id}")]
		[ProducesResponseType(200, Type = typeof(Film))]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Film>> PutAsync(long id, [FromBody] Film film)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var existing = await _context.Films.FindAsync(id);
			if (existing == null)
				 return NotFound();

			film.Id = id;
			_context.Films.Update(film);
			
			await _context.SaveChangesAsync();

			return await GetByIdAsync(id);
		}

		// DELETE api/v1/films/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var existing = await _context.Films.FindAsync(id);
			if (existing == null)
				 return NotFound();

			_context.Films.Remove(existing);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
