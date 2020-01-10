using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.shared
{
	public class Rabbit
	{
		[ForeignKey(nameof(Animal))]
		public int Id { get; set; }
		public string Size { get; set; }
	}
}