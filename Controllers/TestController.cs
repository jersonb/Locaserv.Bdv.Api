using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly LocaservContext _context;

        public TestController(IWebHostEnvironment webHostEnvironment, LocaservContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var test = await _context.Tests.FirstOrDefaultAsync();
            var result = new
            {
                deu_bom = "Sim!",
                envireoment = _webHostEnvironment.EnvironmentName,
                content = test
            };

            return Ok(result);
        }

        [HttpGet("vai")]
        public async Task<IActionResult> Post()
        {
            var a = new Models.Test
            {
                DateTimeOffset = DateTimeOffset.UtcNow,
                DateTime = DateTime.UtcNow,
                DateOnly = DateOnly.FromDateTime(DateTime.Now),
                TimeOnly = TimeOnly.FromDateTime(DateTime.Now),
                Name = "teste"
            };
            await _context.Tests.AddAsync(a);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}