using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locaserv.Bdv.Api.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Uuid = Guid.NewGuid();
            IsActive = true;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("find_id")]
        public Guid Uuid { get; set; }

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