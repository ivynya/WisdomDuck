using System;
using System.Collections.Generic;
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
            ViewData["wisdom"] = DispenseWisdom();
            return View();
        }

        [Route("/wisdom")]
        public IActionResult Wisdom()
        {
            ViewData["wisdom"] = DispenseWisdom();
            return View();
        }

        private string DispenseWisdom()
        {
            Random rnd = new Random();

            return $"{Words.Subject[rnd.Next(0, Words.Subject.Count)]} " +
                   $"{Words.Verb[rnd.Next(0, Words.Verb.Count)]} " +
                   $"{Words.Noun[rnd.Next(0, Words.Noun.Count)]}";
        }

        public IActionResult Privacy()
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
