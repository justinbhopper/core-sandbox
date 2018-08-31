using Microsoft.EntityFrameworkCore;
using Sandbox.Core.Models;

namespace Sandbox.Core
{
	public class SandboxDbContext : DbContext
	{
		public SandboxDbContext(DbContextOptions options)
			: base(options) { }

		public DbSet<Film> Films { get; set; }
	}
}