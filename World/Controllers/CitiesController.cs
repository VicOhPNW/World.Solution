using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using World.Models;
using System;

namespace World.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
            List<City> allCities = City.GetAll();
            return View(allCities);
        }
    }
}