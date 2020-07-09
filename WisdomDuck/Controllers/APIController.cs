using System;
using Microsoft.AspNetCore.Mvc;
using WisdomDuck.Data;

namespace WisdomDuck.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly Persistence _persistence;

        public APIController(Persistence persistence)
        {
            _persistence = persistence;
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
    }
}