using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    [Table("test")]
    public class Test
    {
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("name")]
        public string? Name { get; set; } = null!;

        public DateTimeOffset DateTimeOffset { get; set; }
        public DateTime DateTime { get; set; }
        public DateOnly DateOnly { get; set; }
        public TimeOnly TimeOnly { get; set; }
    }
}