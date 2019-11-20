using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Shelter
	{
		public List<Animal> Animals { get; set; }
		public List<Manager> Managers { get; set; }
		public List<Administrator> Administrators { get; set; }
		public List<Caretaker> Caretakers { get; set; }
	}
}