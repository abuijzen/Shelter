using System;

namespace Shelter.Shared
{
	class Program
	{
		static void Main(string[] args)
		{

			Cat cat1 = new Cat(1, "Felix", "Britse Korthaar", new DateTime(2005, 10, 09), false, true, true, true, new DateTime(2007, 10, 09), "meow I'm a cat", "catnip", true);
			Rabbit rabbit1 = new Rabbit(2, "Ior", "Hollander", new DateTime(2017, 12, 25), false, true, true, true, new DateTime(2018, 09, 10), "Ior is een cutiepie", "nothing", "small");
            Console.WriteLine("Hello World!");
			Console.WriteLine(cat1.Name);
            Console.WriteLine(rabbit1.Name);
		}
	}
}
