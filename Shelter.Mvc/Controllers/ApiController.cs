using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shelter.Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Shelter.Mvc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ApiController : ControllerBase
	{
		private readonly IShelterDataAccess _dataAccess;
		private readonly ILogger<ApiController> _logger;

		public ApiController(ILogger<ApiController> logger, IShelterDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
			_logger = logger;
		}

		[HttpGet]
		/* Alle dieren van ons 1ne asiel zijn hier te vinden, maar dit zou een lijst moeten worden van alle namen +ids van de asielen*/

		public ActionResult<Shelter.Shared.Shelter> Index()
		{
			return AnimalViewModel.Shelter;
		}

		[HttpGet("/")]
		public IActionResult GetAllShelters()
		{
			return Ok(_dataAccess.GetAllShelters());
		}

		[HttpGet("full")]
		public IActionResult GetAllSheltersFull()
		{
			// You return a list here, "not found" is not an issue -- an empty list is still a valid list.
			return Ok(_dataAccess.GetAllSheltersFull());
		}

		[HttpGet("{id}")]
		/* Hier is het de bedoeling dat je de lijst van dieren die in 1 asiel zitten krijgt*/

		public ActionResult<List<Shelter.Shared.Animal>> GetById(int id)
		{
			return AnimalViewModel.Shelter.Animals;
		}

		/* Alle Dieren binnen een Shelter */
		[Route("{id}/animals")]
		public IActionResult GetShelterAnimals(int id)
		{
			var animals = _dataAccess.GetAnimals(id);
			return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
		}

		/* Het dier van een bepaalde shelter zijn info*/

		[HttpGet("{shelterId}/animals/{animalId}")]
		public IActionResult GetAnimalDetails(int shelterId, int animalId)
		{
			var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
			return animal == default(Shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
		}
	}
}