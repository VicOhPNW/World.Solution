using Microsoft.AspNetCore.Mvc;
using World.Models;
using System;
using System.Collections.Generic;

namespace World.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}