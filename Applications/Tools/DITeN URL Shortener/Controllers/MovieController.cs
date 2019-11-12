using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diten.Web.App.Tools.URLShortener.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Diten.Web.App.Tools.URLShortener.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie {Name = "Shrek!"};

            //return View(movie);
            //return Content("Hello World");
            return new EmptyResult();
        }
    }
}