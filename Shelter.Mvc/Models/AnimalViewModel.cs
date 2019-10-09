using System;
using Shelter.Shared;


namespace Shelter.Mvc.Models
{
    public class AnimalViewModel
    {
        public List<Cat> Cat();
        public List<Dog> Dog();
        public List<Rabbit> Rabbit();

        public List<Animal> Animals();
    }
}
