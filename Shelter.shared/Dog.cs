using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.shared
{
	public class Dog
	{
		[ForeignKey(nameof(Animal))]
		public int Id { get; set; }
		public bool Barker { get; set; }

	}
}