using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    [Table("conductor_vehicle")]
    public class ConductorVehicle : EntityBase
    {
        [Column("conductor_id")]
        public long ConductorId { get; set; }

        public Conductor Conductor { get; set; } = new();

        [Column("vehicle_id")]
        public long VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = new();
    }
}