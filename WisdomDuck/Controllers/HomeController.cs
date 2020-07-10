using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WisdomDuck.Data;
using WisdomDuck.Models;

namespace WisdomDuck.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/wisdom")]
        public IActionResult Wisdom()
        {
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/moving")]
        public IActionResult Moving()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
