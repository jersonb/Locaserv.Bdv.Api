using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    [Table("conductor")]
    public class Conductor : EntityBase
    {
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; init; } = string.Empty;

        [MaxLength(30)]
        [Column("code")]
        public string Code { get; init; } = string.Empty;

        public ICollection<ConductorVehicle> ConductorsVehicles { get; set; } = new HashSet<ConductorVehicle>();
    }
}