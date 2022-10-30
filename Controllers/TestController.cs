using Microsoft.AspNetCore.Mvc;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("ok")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOk()
        {
            return Ok();
        }

        [HttpGet("accepted")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult GetAccepted()
        {
            return Accepted();
        }

        [HttpGet("not-found")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("unauthorized")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("bad-request")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetInternalServerError()
        {
            throw new Exception();
        }
    }
}