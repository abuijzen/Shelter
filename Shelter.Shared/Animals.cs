using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    class Animals
    {
        public class Animal
        {
            public Animal(int id, string name, dateTime dateOfBirth, bool isChecked, bool kidFriendly, dateTime since)
            {
                Id=id;
                Name=name;
                DateOfBirth=dateOfBirth;
                IsChecked=isChecked;
                KidFriendly=kidFriendly;
                Since=since;
            }
        }
    }
}
