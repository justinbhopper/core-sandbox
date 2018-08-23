using Microsoft.EntityFrameworkCore;

namespace Sandbox.Models
{
	public class SandboxDbContext : DbContext
	{
		public SandboxDbContext(DbContextOptions<SandboxDbContext> options)
			: base(options) { }

		public DbSet<Film> Films { get; set; }
	}
}