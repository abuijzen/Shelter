using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.shared
{
	public class Cat
	{
		[ForeignKey(nameof(Animal))]
		public int Id { get; set; }
		public bool Clawed { get; set; }
	}
}