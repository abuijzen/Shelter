using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    class Animals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Animals Class 🐶🐱🐹");
        }

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
