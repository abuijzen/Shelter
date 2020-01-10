using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shelter.shared;
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
		public ActionResult<Shelter.shared.Shelter> Index()
		{
			return Ok(_dataAccess.GetAllSheltersFull());
		}

		[HttpGet("/")]
		public IActionResult GetAllShelters()
		{
			return Ok(_dataAccess.GetAllShelters());
		}

		[HttpGet("full")]
		public IActionResult GetAllSheltersFull()
		{
			return Ok(_dataAccess.GetAllSheltersFull());
		}

		[HttpGet("{id}")]
		/* Hier is het de bedoeling dat je de lijst van dieren die in 1 asiel zitten krijgt*/
		 public IActionResult GetShelter(int id)
    		{
    
      			var shelter = _dataAccess.GetShelterById(id); 
      			return shelter == default(shared.Shelter) ? (IActionResult)NotFound() : Ok(shelter);
    }


		




		/* Alle Dieren binnen een Shelter */
		[HttpGet("{id}/animals")]
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
			return animal == default(shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
		}

		[HttpPut("{shelterId}/animals/{animalId}")]
		public IActionResult UpdateAnimal(int shelterId, int animalId, [FromBody]shared.Animal animal)
		{
			return Ok(animal);
		}


		[HttpGet("{shelterId}/animals/{animalName}")]
		public IActionResult CheckIfUnique(int shelterId, string animalName)
		{
			var animal = _dataAccess.CheckIfUnique(shelterId, animalName);
			return animal == default(shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
		}

	}
}
 