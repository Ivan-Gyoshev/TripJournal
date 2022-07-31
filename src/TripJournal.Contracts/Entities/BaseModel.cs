using System.ComponentModel.DataAnnotations;

namespace TripJournal.Contracts.Entities
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
