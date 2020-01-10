using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.shared
{
	public class ShelterContext : DbContext
	{
		public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
		{

		}

		public DbSet<Animal> Animals { get; set; }
		public DbSet<Shelter> Shelters { get; set; }
		public DbSet<Employees> Employees { get; set; }
	}
}