using Microsoft.EntityFrameworkCore;
using Sandbox.Data.Models;

namespace Sandbox.Data
{
	public class SandboxDbContext : DbContext
	{
		public SandboxDbContext(DbContextOptions options)
			: base(options) { }

		public DbSet<Film> Films { get; set; }
	}
}