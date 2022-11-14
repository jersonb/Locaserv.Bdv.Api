using Locaserv.Bdv.Api.Data;
using Locaserv.Bdv.Api.Models;
using Locaserv.Bdv.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locaserv.Bdv.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILocaservContext context;

        public VehiclesController(ILocaservContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await context.Vehicles
                .AsNoTracking()
                .Where(car => car.IsActive)
                .Select(car => (DetailCarViewModel)car)
                .ToListAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{uuid:guid}")]
        public async Task<IActionResult> GetById(Guid uuid, CancellationToken cancellationToken)
        {
            var result = await context.Vehicles
                .AsNoTracking()
                .Where(car => car.IsActive && car.Uuid == uuid)
                .Select(car => (DetailCarViewModel)car)
                .SingleAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarViewModel createCar, CancellationToken cancellationToken)
        {
            var car = (Vehicle)createCar;

            var arredyExists = await context.Vehicles.AnyAsync(c =>
               c.Uuid == car.Uuid
            || c.InternalCode == car.InternalCode
            || c.LicensePlate == car.LicensePlate, cancellationToken);

            if (arredyExists)
                throw new Exception();

            await context.Vehicles.AddAsync(car, cancellationToken);
            var rowsAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowsAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = car.Uuid }, null);
        }

        [HttpPut("{uuid:guid}")]
        public async Task<IActionResult> Put(UpdateCarViewModel car, Guid uuid, CancellationToken cancellationToken)
        {
            if (car.Uuid != uuid)
                throw new Exception();

            var model = await context.Vehicles.SingleAsync(x => x.Uuid == uuid, cancellationToken);

            model.UpdatedAtAt = DateTime.UtcNow;
            model.LicensePlate = car.LicensePlate;
            model.InternalCode = car.InternalCode;

            context.Vehicles.Update(model);
            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = model.Uuid }, null);
        }

        [HttpDelete("{uuid:guid}")]
        public async Task<IActionResult> Delete(DeleteCarViewModel car, Guid uuid, CancellationToken cancellationToken)
        {
            if (car.Uuid != uuid)
                throw new Exception();

            var model = await context.Vehicles.SingleAsync(x => x.Uuid == uuid, cancellationToken);
            model.Delete();

            context.Vehicles.Update(model);
            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return NoContent();
        }
    }
}