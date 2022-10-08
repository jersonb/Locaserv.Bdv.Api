using Microsoft.AspNetCore.Mvc;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok("Deu bom!");
    }
}