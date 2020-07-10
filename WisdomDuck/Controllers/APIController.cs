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
            return "📦 Duck is moving. This API is deprecated - use the new one at https://wisdomduck.sdbagel.com/api/wisdom/dispense.";
        }
    }
}