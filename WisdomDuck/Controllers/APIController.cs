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
        public IActionResult GetWisdom()
        {
            return RedirectPermanent("https://wisdomduck.sdbagel.com/api/wisdom/dispense");
        }
    }
}