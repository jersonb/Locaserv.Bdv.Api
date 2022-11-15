using Locaserv.Bdv.Api.Data;
using Locaserv.Bdv.Api.Models;
using Locaserv.Bdv.Api.ViewModels;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DetailConductorViewModel>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await context.Conductors
               .AsNoTracking()
               .Where(conductor => conductor.IsActive)
               .Select(conductor => (DetailConductorViewModel)conductor)
               .ToListAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetailConductorViewModel))]
        public async Task<IActionResult> GetById(Guid uuid, CancellationToken cancellationToken)
        {
            var result = await context.Conductors
               .AsNoTracking()
               .Where(conductor => conductor.IsActive && conductor.Uuid == uuid)
               .Select(conductor => (DetailConductorViewModel)conductor)
               .SingleAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateConductorViewMode createConductor, CancellationToken cancellationToken)
        {
            var conductor = (Conductor)createConductor;

            var alreadyExists = await context.Conductors
                .AsNoTracking()
                .AnyAsync(c => c.Uuid == conductor.Uuid
                                    || c.Name == conductor.Name
                                    || c.Code == conductor.Code, cancellationToken);

            if (alreadyExists)
                throw new Exception();

            await context.Conductors.AddAsync(conductor, cancellationToken);
            var rowsAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowsAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = conductor.Uuid }, null);
        }

        [HttpPut("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Put(UpdateConductorViewModel conductor, Guid uuid, CancellationToken cancellationToken)
        {
            if (conductor.Uuid != uuid)
                throw new Exception();

            var alreadyExists = await context.Conductors
                .AsNoTracking()
                .AnyAsync(c => c.Uuid != conductor.Uuid &&
                                 (c.Name == conductor.Name || c.Code == conductor.Code), cancellationToken);

            if (alreadyExists)
                throw new Exception();

            var model = await context.Conductors.SingleAsync(c => c.Uuid == conductor.Uuid, cancellationToken);

            model.UpdatedAtAt = DateTimeOffset.UtcNow;
            model.Code = conductor.Code;
            model.Name = conductor.Name;

            context.Conductors.Update(model);

            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = conductor.Uuid }, null);
        }

        [HttpDelete("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteConductorViewMode conductor, Guid uuid, CancellationToken cancellationToken)
        {
            if (conductor.Uuid != uuid)
                throw new Exception();

            var model = await context.Conductors.SingleAsync(c => c.Uuid == uuid, cancellationToken);
            model.Delete();

            context.Conductors.Update(model);
            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return NoContent();
        }
    }
}