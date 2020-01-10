using System;
using System.Collections.Generic;

namespace Shelter.shared
{
	public class Animal : BaseDbClass
	{
        // Dit is een lege constructor die de base is bij cat, dog, rabbit

		public string Name { get; set; }
		public string Race { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool IsFertile { get; set; }
		public bool IsKidFriendly { get; set; }
		public bool IsAnimalFriendly { get; set; }
		public bool IsSpeciesFriendly { get; set; }
		public DateTime Since { get; set; }
		public string Bio { get; set; }
		public string Allergies { get; set; }
		public int ShelterId { get; set; }

}
	
}
