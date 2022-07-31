namespace TripJournal.Contracts.Entities
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }
    }
}
