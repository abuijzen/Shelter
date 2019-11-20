using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Shelter
	{
		public string Id { get; set; }
		public string name { get; set; }
		public string imageUrl { get; set; }
		public string address { get; set; }
		public string telephoneNumber { get; set; }
		public string emailAdress { get; set; }
		public List<Animal> Animals { get; set; }
		public List<Manager> Managers { get; set; }
		public List<Administrator> Administrators { get; set; }
		public List<Caretaker> Caretakers { get; set; }
	}
}