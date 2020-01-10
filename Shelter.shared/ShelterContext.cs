using Microsoft.EntityFrameworkCore;
using System;
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
		public DbSet<Cat> Cats { get; set; }
		public DbSet<Rabbit> Rabits { get; set; }
		public DbSet<Dog> Dogs { get; set; }
		public DbSet<Shelter> Shelters { get; set; }
		public DbSet<Employees> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Shelter>(entity =>
			   {
				   entity.ToTable("Shelters");

				   entity.Property(e => e.Name)
					   .IsRequired()
					   .HasMaxLength(50);
			   });

			modelBuilder.Entity<Shelter>().HasData(
			   	new Shelter { Id = 1, Name = "Canina", ImageUrl = "canina", Address = "Kievitstraat 40", TelephoneNumber = "036771291", EmailAdress = "/", },
			   	new Shelter { Id = 2, Name = "Veeweyde vzw", ImageUrl = "image", Address = "Toekomststraat 4", TelephoneNumber = "014658626", EmailAdress = "veeweyde.weelde@skynet.be", },
			   	new Shelter { Id = 3, Name = "kat-lijn vzw", ImageUrl = "https://www.dierendonatie.be/wp-content/uploads/2019/01/29570550_2080399628857532_4696137069563272630_n.jpg", Address = "Houwaartstraat 15, 3210 Lubbeek", TelephoneNumber = "0468 56 93 72", EmailAdress = "info@kat-lijn.be", }
			);

			modelBuilder.Entity<Animal>(entity =>
			   {
				   entity.ToTable("Animals");

				   entity.Property(e => e.Name)
					   .IsRequired()
					   .HasMaxLength(50);
			   });

			modelBuilder.Entity<Animal>()
				.OwnsOne(a => a.Publisher)
				.HasData(


				);

			modelBuilder.Entity<Cat>(entity =>
			{
				entity.ToTable("Cats");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Cat>().HasData(
				//Shelter 1
				new Cat { Id = 1, AnimalId = 1, Name = "Felix", Race = "Britse Korthaar", DateOfBirth = new DateTime(2005, 10, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Felix is een iets schuwere kat die een baasje nodig heeft met veel geduld.", Allergies = "catnip", ShelterId = 1, Clawed = true },
				new Cat { Id = 2, AnimalId = 2, Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2005, 03, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Picasso is een kat die samen met Binky geplaatst dient te worden.", Allergies = "dogs", ShelterId = 1, Clawed = true },
				new Cat { Id = 4, AnimalId = 4, Name = "Minoes", Race = "Europese Korthaar", DateOfBirth = new DateTime(2010, 10, 09), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 10, 09), Bio = "Minoes is een sociale en lieve kitten die net van een nestje komt.", Allergies = "geen", ShelterId = 1, Clawed = true },
				new Cat { Id = 5, AnimalId = 5, Name = "Binky", Race = "Europese Korthaar", DateOfBirth = new DateTime(2016, 11, 13), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 12, 09), Bio = "Binky is een kat die samen met Picasso geplaatst dient te worden.", Allergies = "geen", ShelterId = 1, Clawed = true },

				//Shelter 2
				new Cat { Id = 7, AnimalId = 7, Name = "Ludo", Race = "Europeese korthaar", DateOfBirth = new DateTime(2015, 12, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2018, 02, 21), Bio = "Ludo is een lievertje maar niet voor andere dieren.", Allergies = "geen", ShelterId = 2, Clawed = true },
				new Cat { Id = 9, AnimalId = 9, Name = "Moesti", Race = "Europeese korthaar", DateOfBirth = new DateTime(2014, 03, 02), IsFertile = false, IsKidFriendly = false, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2016, 07, 17), Bio = "Moesti is een echte dierenvriend van kleine kinderen houden ze niet", Allergies = "geen", ShelterId = 2, Clawed = true },

				//Shelter 3
				new Cat { Id = 15, AnimalId = 15, Name = "Wolf", Race = "Bombay ", DateOfBirth = new DateTime(2003, 07, 22), IsFertile = true, IsKidFriendly = false, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2004, 12, 01), Bio = "Een kat met de nodige kattenstreken.", Allergies = "geen", ShelterId = 3, Clawed = true },
				new Cat { Id = 16, AnimalId = 16, Name = "Pom pom", Race = "Bengaalse tijgerkat", DateOfBirth = new DateTime(2007, 03, 29), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2010, 01, 15), Bio = "Een lieverd, begroet iedereen met een kopstootje.", Allergies = "geen", ShelterId = 3, Clawed = true }
			);

			modelBuilder.Entity<Rabbit>(entity =>
			{
				entity.ToTable("Rabbits");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Rabbit>().HasData(
				//Shelter 1
				new Rabbit { Id = 3, AnimalId = 3, Name = "Ior", Race = "Hollander", DateOfBirth = new DateTime(2017, 12, 25), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 09, 10), Bio = "Ior is een kindvriendelijk konijn die graag bij andere konijntjes gezet wordt indien mogelijk.", Allergies = "none", ShelterId = 1, Size = "groot" },

				//Shelter 2
				new Rabbit { Id = 11, AnimalId = 11, Name = "Olaf", Race = "Rijnlander", DateOfBirth = new DateTime(2017, 10, 15), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 10, 17), Bio = "Olaf is een vinnig beestje, perfect voor jonge gezinnen", Allergies = "geen", ShelterId = 2, Size = "groot" },
				new Rabbit { Id = 12, AnimalId = 12, Name = "Garret", Race = "Franse Hangoor", DateOfBirth = new DateTime(2015, 08, 20), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2019, 10, 11), Bio = "Garret houd van kinderen en mensen, van andere dieren gaat hij lopen.", Allergies = "geen", ShelterId = 2, Size = "groot" },

				//Shelter 3
				new Rabbit { Id = 17, AnimalId = 17, Name = "Nijntje", Race = "Kleurdwerg", DateOfBirth = new DateTime(2018, 04, 05), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = false, Since = new DateTime(2018, 08, 06), Bio = "Nijntje, lief klein konijntje.", Allergies = "wortels", ShelterId = 2, Size = "small" },
				new Rabbit { Id = 18, AnimalId = 18, Name = "Sneeuwtje", Race = "Amerikaanse konijn", DateOfBirth = new DateTime(2019, 08, 01), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = false, Since = new DateTime(2019, 10, 30), Bio = "Een witte konijn met een hoge aaibaarheidsfactor.", Allergies = "rinitis", ShelterId = 3, Size = "small" }
			);

			modelBuilder.Entity<Dog>(entity =>
			{
				entity.ToTable("Dogs");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Dog>().HasData(
				//Shelter 1
				new Dog { Id = 6, AnimalId = 6, Name = "Mopsie", Race = "Mopshond", DateOfBirth = new DateTime(2017, 12, 25), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 09, 10), Bio = "Mopsie is een gezonde mopshond gered uit de broodfok", Allergies = "Chocolade", ShelterId = 1, Barker = false },

				//Shelter 2
				new Dog { Id = 8, AnimalId = 8, Name = "Puk", Race = "Franse Bulldog", DateOfBirth = new DateTime(2018, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 05, 20), Bio = "Puk is een echte ronkende franse buldog, door gezondheidsproblemen is hij bij ons beland", Allergies = "Kip", ShelterId = 2, Barker = true },
				new Dog { Id = 10, AnimalId = 10, Name = "Marcel", Race = "Teckel", DateOfBirth = new DateTime(2009, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 09, 20), Bio = "Marcel is een oude gek, op zijn oude dag heeft hij nog veel liefde voor tennisballen", Allergies = "geen", ShelterId = 2, Barker = false },
				new Dog { Id = 13, AnimalId = 13, Name = "Astrix", Race = "Mastino Napoletano", DateOfBirth = new DateTime(2017, 02, 12), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = true, Since = new DateTime(2018, 10, 22), Bio = "Astrix is een grote jongen die veel liefde geeft", Allergies = "geen", ShelterId = 2, Barker = true },
				new Dog { Id = 14, AnimalId = 14, Name = "Rock", Race = "Staffordshire Bull Terrier", DateOfBirth = new DateTime(2016, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2017, 11, 09), Bio = "Rock is een grote dikke vriend van iedereen", Allergies = "kip", ShelterId = 2, Barker = true },

				//Shelter 3
				new Dog { Id = 19, AnimalId = 15, Name = "Mimi", Race = "Pommeriaan", DateOfBirth = new DateTime(2002, 11, 01), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2018, 02, 27), Bio = "Mimi is bang voor veel dingen maar overwint haar angsten voor haar baasjes.", Allergies = "geen", ShelterId = 3, Barker = true },
				new Dog { Id = 20, AnimalId = 16, Name = "Elisabeth III", Race = "Bobtail", DateOfBirth = new DateTime(2019, 10, 30), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 11, 28), Bio = "Een jong meisje met klasse, dat is Elisabeth III", Allergies = "kip", ShelterId = 3, Barker = true }
			);
		}
	}
}