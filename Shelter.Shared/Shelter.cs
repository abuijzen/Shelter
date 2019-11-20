using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Shelter
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string Address { get; set; }
		public string TelephoneNumber { get; set; }
		public string EmailAdress { get; set; }
		public List<Animal> Animals { get; set; }
		public List<Manager> Managers { get; set; }
		public List<Administrator> Administrators { get; set; }
		public List<Caretaker> Caretakers { get; set; }
	}
}