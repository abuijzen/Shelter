using Microsoft.EntityFrameworkCore;

namespace Shelter.Shared
{
    public class ShelterContext : DbContext
    {
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Rabbit> Rabbits { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}