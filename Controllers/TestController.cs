using Microsoft.AspNetCore.Mvc;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok("Deu bom!");
    }
}