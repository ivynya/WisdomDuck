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
            return RedirectPermanent("https://wisdomduck.sdbagel.com/");
        }

        [Route("/wisdom")]
        public IActionResult Wisdom()
        {
            return RedirectPermanent("https://wisdomduck.sdbagel.com/Wisdom");
        }

        public IActionResult Privacy()
        {
            return RedirectPermanent("https://wisdomduck.sdbagel.com/Home/Privacy");
        }

        [HttpGet("/moving")]
        public IActionResult Moving()
        {
            return RedirectPermanent("https://wisdomduck.sdbagel.com/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
