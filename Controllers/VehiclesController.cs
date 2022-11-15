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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DetailVehicleViewModel>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await context.Vehicles
                .AsNoTracking()
                .Where(vehicle => vehicle.IsActive)
                .Select(vehicle => (DetailVehicleViewModel)vehicle)
                .ToListAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetailVehicleViewModel))]
        public async Task<IActionResult> GetById(Guid uuid, CancellationToken cancellationToken)
        {
            var result = await context.Vehicles
                .AsNoTracking()
                .Where(vehicle => vehicle.IsActive && vehicle.Uuid == uuid)
                .Select(vehicle => (DetailVehicleViewModel)vehicle)
                .SingleAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateVehicleViewModel createVehicle, CancellationToken cancellationToken)
        {
            var vehicle = (Vehicle)createVehicle;

            var alredyExists = await context.Vehicles
                .AsNoTracking()
                .AnyAsync(v => v.Uuid == vehicle.Uuid
                                  || v.InternalCode == vehicle.InternalCode
                                  || v.LicensePlate == vehicle.LicensePlate, cancellationToken);

            if (alredyExists)
                throw new Exception();

            await context.Vehicles.AddAsync(vehicle, cancellationToken);
            var rowsAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowsAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = vehicle.Uuid }, null);
        }

        [HttpPut("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Put(UpdateVehicleViewModel vehicle, Guid uuid, CancellationToken cancellationToken)
        {
            if (vehicle.Uuid != uuid)
                throw new Exception();

            var alreadyExists = await context.Vehicles
                .AsNoTracking()
                .AnyAsync(v => v.Uuid != vehicle.Uuid &&
                               (v.LicensePlate == vehicle.LicensePlate || v.InternalCode == vehicle.InternalCode), cancellationToken);

            if (alreadyExists)
                throw new Exception();

            var model = await context.Vehicles.SingleAsync(v => v.Uuid == uuid, cancellationToken);

            model.UpdatedAtAt = DateTimeOffset.UtcNow;
            model.LicensePlate = vehicle.LicensePlate;
            model.InternalCode = vehicle.InternalCode;

            context.Vehicles.Update(model);

            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return CreatedAtAction(nameof(GetById), new { uuid = model.Uuid }, null);
        }

        [HttpDelete("{uuid:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteVehicleViewModel vehicle, Guid uuid, CancellationToken cancellationToken)
        {
            if (vehicle.Uuid != uuid)
                throw new Exception();

            var model = await context.Vehicles.SingleAsync(v => v.Uuid == uuid, cancellationToken);
            model.Delete();

            context.Vehicles.Update(model);
            var rowAfected = await context.SaveChangesAsync(cancellationToken);

            if (rowAfected == 0)
                throw new Exception();

            return NoContent();
        }
    }
}