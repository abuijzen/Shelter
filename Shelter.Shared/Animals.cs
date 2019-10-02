using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    class Animals
    {
        public class Animal
        {
            public Animal(int id,
                            string name,
                            string race,
                            DateTime dateOfBirth,
                            bool isFertile,
                            string kidFriendly,
                            string animalFriendly,
                            string speciesFriendly,
                            DateTime since,
                            string bio,
                            string alergies)
                        {
                Id=id;
                Name=name;
                Race =race;
                DateOfBirth=dateOfBirth;
                IsFertile= isFertile;
                KidFriendly=kidFriendly;
                AnimalFriendly=animalFriendly;
                SpeciesFriendly=speciesFriendly;
                Since=since;
                Bio=bio;
                Alergies=alergies;



            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Race { get; set; }
            public DateTime DateOfBirth { get; set; }
            public bool IsFertile { get; set; }
            public string KidFriendly { get; set; }
            public string AnimalFriendly { get; set; }
            public string SpeciesFriendly { get; set; }
            public DateTime Since { get; set; }

            public string Bio { get; set; }

            public string Alergies { get; set; }


        }
    }
}
