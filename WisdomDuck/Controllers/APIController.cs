using System;
using Microsoft.AspNetCore.Mvc;
using WisdomDuck.Data;

namespace WisdomDuck.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet("wisdom/dispense")]
        public string GetWisdom()
        {
            Random rnd = new Random();
            return $"{Words.Subject[rnd.Next(0, Words.Subject.Count)]} " +
                   $"{Words.Verb[rnd.Next(0, Words.Verb.Count)]} " +
                   $"{Words.Noun[rnd.Next(0, Words.Noun.Count)]}";
        }
    }
}