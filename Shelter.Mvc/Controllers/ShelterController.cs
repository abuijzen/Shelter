using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelter.Mvc.Models;

namespace Shelter.Mvc.Controllers
{
    public class ShelterController : Controller
    {
  public IActionResult Index()
{
 
   return View();
}
    }


  
}