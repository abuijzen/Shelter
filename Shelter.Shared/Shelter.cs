using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Shelter
	{
		public Shelter()
		{

		}

		public Shelter(string id,
					string name,
					string imageUrl,
					string address,
					string telephoneNumber,
					string emailAdress,
					Administrator administrators,
					Caretaker caretakers,
					Animals animals)
		{
			Id = id;
			Name = name;
			ImageUrl = imageUrl;
			Address = address;
			TelephoneNumber = telephoneNumber;
			EmailAdress = emailAdress;
			Administrators = administrators;
			Caretaker = caretaker;
			Animals = animals;
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string Address { get; set; }
		public string TelephoneNumber { get; set; }
		public string EmailAdress { get; set; }
		public Administrator Administrators { get; set; }
		public Caretaker Caretaker { get; set; }
		public Animals Animals { get; set; }
	}
}