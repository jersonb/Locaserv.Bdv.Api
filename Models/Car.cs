using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    [Table("car")]
    public class Car
    {
        public Car()
        {
            Uuid = Guid.NewGuid();
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("find_id")]
        public Guid Uuid { get; set; }

        [MaxLength(10)]
        [Column("internal_code")]
        public string InternalCode { get; set; } = string.Empty;

        [MaxLength(10)]
        [Column("license_plate")]
        public string LicensePlate { get; set; } = string.Empty;

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset? UpdatedAtAt { get; set; }

        [Column("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }

        public void Delete()
        {
            IsActive = false;
            DeletedAt = DateTimeOffset.UtcNow;
        }
    }
}