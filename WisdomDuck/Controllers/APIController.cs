using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public string GetWisdom()
        {
            _persistence.APIDispensations += 1;

            Random rnd = new Random();
            return $"{Words.Subject[rnd.Next(0, Words.Subject.Count)]} " +
                   $"{Words.Verb[rnd.Next(0, Words.Verb.Count)]} " +
                   $"{Words.Noun[rnd.Next(0, Words.Noun.Count)]}";
        }

        [HttpGet("wisdom/stats")]
        public string GetStats()
        {
            return $"{_persistence.Visitors} Visitors, " +
                   $"{_persistence.APIDispensations} API Dispensations, " +
                   $"{_persistence.LegacyDispensations} Legacy Dispensations";
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