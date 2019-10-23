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

			return View(AnimalViewModel.Shelter);
		}

		public IActionResult Detail(int id)
		{
			var currentAnimal = AnimalViewModel.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (currentAnimal == default(Animal))
			{
				return NotFound();
			}
			return View(currentAnimal);
		}

		public IActionResult Delete(int id)
		{
			var currentAnimal = AnimalViewModel.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (currentAnimal == default(Animal))
			{
				return NotFound();
			}
			return View(currentAnimal);
		}

		[HttpPost]
		public IActionResult DoDelete(int id)
		{
			var currentAnimal = AnimalViewModel.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (currentAnimal == default(Animal))
			{
				return NotFound();
			}
			AnimalViewModel.Shelter.Animals.Remove(currentAnimal);
			return RedirectToAction(nameof(Index));

		}
	}
}
