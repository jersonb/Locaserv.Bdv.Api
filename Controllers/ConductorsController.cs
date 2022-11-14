using Locaserv.Bdv.Api.Data;
using Locaserv.Bdv.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConductorsController : ControllerBase
    {
        private readonly ILocaservContext context;

        public ConductorsController(ILocaservContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var conductors = await context.Conductors.AsNoTracking().ToListAsync(cancellationToken);
            return Ok(conductors);
        }

        [HttpGet("uuid:guid")]
        public async Task<IActionResult> GetById(Guid uuid, CancellationToken cancellationToken)
        {
            var conductor = await context.Conductors.AsNoTracking().SingleOrDefaultAsync(c => c.Uuid == uuid, cancellationToken);
            return Ok(conductor);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Conductor conductor, CancellationToken cancellationToken)
        {
            context.Conductors.Add(conductor);
            var rowsAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowsAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = conductor.Uuid }, null);
        }

        [HttpPut("{uuid:guid}")]
        public async Task<IActionResult> Put(Conductor conductor, CancellationToken cancellationToken)
        {
            context.Conductors.Update(conductor);

            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = conductor.Uuid }, null);
        }

        [HttpDelete("{uuid:guid}")]
        public async Task<IActionResult> Delete(Guid uuid, CancellationToken cancellationToken)
        {
            var conductor = await context.Conductors.SingleOrDefaultAsync(c => c.Uuid == uuid, cancellationToken);

            conductor.Delete();

            context.Conductors.Update(conductor);
            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return NoContent();
        }
    }
}