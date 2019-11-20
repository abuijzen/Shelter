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

namespace Shelter.Mvc.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class ApiController : ControllerBase
	{
		[HttpGet]
		/* Alle dieren van ons 1ne asiel zijn hier te vinden, maar dit zou een lijst moeten worden van alle namen +ids van de asielen*/

		public ActionResult<Shelter.Shared.Shelter> Index()
		{
			return AnimalViewModel.Shelter;
		}

		[HttpGet("{id}")]
		/* Hier is het de bedoeling dat je de lijst van dieren die in 1 asiel zitten krijgt*/

		public ActionResult<List<Shelter.Shared.Animal>> GetById(int id)
		{
			return AnimalViewModel.Shelter.Animals;
		}


	}
}