using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WisdomDuck.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly List<string> Subject = new List<string>
        {
            "Duck",
            "He",
            "They",
            "It",
            "She",
            "That",
            "Wisdom",
            "You"
        };

        private readonly List<string> Verb = new List<string>
        {
            "perceives",
            "understands",
            "values",
            "exemplifies",
            "is",
            "has",
            "delivers",
            "provides",
            "consumes",
            "abolishes",
            "accelerates",
            "achieves",
            "acts with"
        };

        private readonly List<string> Noun = new List<string>
        {
            "friendship",
            "kindness",
            "compassion",
            "love",
            "care",
            "entertainment",
            "judgement",
            "jurisdiction",
            "beauty",
            "play",
            "art",
            "understanding",
            "knowledge",
            "theory",
            "power",
            "development",
            "strategy"
        };

        [HttpGet("wisdom/dispense")]
        public string GetWisdom()
        {
            Random rnd = new Random();

            return $"{Subject[rnd.Next(0, Subject.Count)]} {Verb[rnd.Next(0, Verb.Count)]} {Noun[rnd.Next(0, Noun.Count)]}";
        }
    }
}