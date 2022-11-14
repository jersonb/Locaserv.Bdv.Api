using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    [Table("vehicle")]
    public class Vehicle : EntityBase
    {
        [MaxLength(10)]
        [Column("internal_code")]
        public string InternalCode { get; set; } = string.Empty;

        [MaxLength(10)]
        [Column("license_plate")]
        public string LicensePlate { get; set; } = string.Empty;

        public ICollection<ConductorVehicle> ConductorsVehicles { get; set; } = new HashSet<ConductorVehicle>();
    }
}