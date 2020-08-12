using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WisdomDuck.Data;
using WisdomDuck.Models;

namespace WisdomDuck.Controllers
{
    public class HomeController : Controller
    {
        private readonly Persistence _persistence;

        public HomeController(Persistence persistence)
        {
            _persistence = persistence;
        }

        public IActionResult Index(string re = null)
        {
            ViewData["wisdom"] = DispenseWisdom();
            _persistence.Visitors += 1;

            if (re != null)
            {
                var referral = _persistence.Referrals.FirstOrDefault(r => r.From == re);
                if (referral == null)
                {
                    referral = new Persistence.Referral
                    {
                        From = re,
                        Visitors = 1,
                        APIDispensations = 0
                    };
                    _persistence.Referrals.Add(referral);
                }
                else referral.Visitors += 1;
            }

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
            _persistence.LegacyDispensations += 1;
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
