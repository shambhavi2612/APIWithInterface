using CRUDThroughInterface.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDThroughInterface
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Students> Students { get; set; }
	}

	
}
