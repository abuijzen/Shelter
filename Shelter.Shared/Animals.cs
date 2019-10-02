using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    class Animals
    {
        public class Animal
        {
            public Animal(int id, string name, string race,dateTime dateOfBirth, bool fertile,string kidFriendly, string animalFriendly, string speciesFriendly, dateTime since, string bio)
            {
                Id=id;
                Name=name;
                Race =race;
                DateOfBirth=dateOfBirth;
                Fertile=fertile;
                KidFriendly=kidFriendly;
                AnimalFriendly=animalFriendly;
                SpeciesFriendly=speciesFriendly;
                Since=since;
                Bio=bio;
            }
        }
    }
}
