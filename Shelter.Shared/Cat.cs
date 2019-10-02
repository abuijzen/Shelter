using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	class Cat: Animals
	{
		public Cat() : base()
		{

		}

		public Cat(int id,
                            string name,
                            string race,
                            DateTime dateOfBirth,
                            bool isFertile,
                            string kidFriendly,
                            string animalFriendly,
                            string speciesFriendly,
                            DateTime since,
                            string bio,
                            string alergies,
							bool clawed) /*extra toegevoegde data */
					
					: base(	id,
							name,
							race,
							dateOfBirth,
							isFertile,
							kidFriendly,
							animalFriendly,
							speciesFriendly,
							since,
							bio,
							alergies){

		}

	}
}