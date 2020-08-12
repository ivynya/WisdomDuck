using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WisdomDuck.Data;

namespace WisdomDuck.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly Persistence _persistence;
        private readonly IConfiguration _config;

        public APIController(Persistence persistence, IConfiguration configuration)
        {
            _persistence = persistence;
            _config = configuration;
        }

        [HttpGet("wisdom/dispense")]
        public string GetWisdom(string re = null)
        {
            _persistence.APIDispensations += 1;

            if (re != null)
            {
                var referral = _persistence.Referrals.FirstOrDefault(r => r.From == re);
                if (referral == null)
                {
                    referral = new Persistence.Referral
                    {
                        From = re,
                        Visitors = 0,
                        APIDispensations = 1
                    };
                    _persistence.Referrals.Add(referral);
                }
                else referral.APIDispensations += 1;
            }

            Random rnd = new Random();
            return $"{Words.Subject[rnd.Next(0, Words.Subject.Count)]} " +
                   $"{Words.Verb[rnd.Next(0, Words.Verb.Count)]} " +
                   $"{Words.Noun[rnd.Next(0, Words.Noun.Count)]}";
        }

        [HttpGet("wisdom/stats")]
        public string GetStats()
        {
            return JsonConvert.SerializeObject(_persistence, Formatting.Indented);
        }

        [HttpPatch("wisdom/stats")]
        public IActionResult SetStats(int v, int a, int l, string p)
        {
            if (p == _config["password"])
            {
                _persistence.Visitors += v;
                _persistence.APIDispensations += a;
                _persistence.LegacyDispensations += l;
                return StatusCode(204);
            }
            else return StatusCode(403);
        }
    }
}