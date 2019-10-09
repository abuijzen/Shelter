using System;

namespace Shelter.Shared
{
    class Program
    {
        static void Main(string[] args)
        {

            Cat cat1 = new Cat(1,"Felix","Britse Korthaar",new DateTime(2005,10,09),false,true,true,true,new DateTime(2007,10,09),"meow I'm a cat","catnip",true);
            Console.WriteLine("Hello World!");
        }
    }
}
