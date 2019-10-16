using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelter.Mvc.Models;
using Shelter.Shared;

namespace Shelter.Mvc.Controllers
{
	public class ShelterController : Controller
	{
		private readonly ILogger<ShelterController> _logger;

		public ShelterController(ILogger<ShelterController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			// opbouwen van het view model en in het view model steken


			var cat1 = new Cat(1, "Felix", "Britse Korthaar", new DateTime(2005, 10, 09), false, true, true, true, new DateTime(2007, 10, 09), "meow I'm a cat", "catnip", true);
			var cat2 = new Cat(2, "Picasso", "Ragdoll", new DateTime(2010, 03, 10), false, true, true, true, new DateTime(2011, 08, 10), "Mieeeuw", "dogs", true);
			var rabbit1 = new Rabbit(2, "Ior", "Hollander", new DateTime(2017, 12, 25), false, true, true, true, new DateTime(2018, 09, 10), "Ior is een cutiepie", "nothing", "small");

			return View(new AnimalViewModel { Animals = new List<Animal> { cat1, rabbit1, cat2 } });
		}

		public IActionResult Delete(int id)
		{
			var currentAnimal = ShelterController.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (currentAnimal == default(Beer))
			{
				return NotFound();
			}
			return View(currentAnimal);
		}
	}
}
