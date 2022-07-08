namespace TripJournal.Contracts.Entities
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTimeOffset? DeletedOn { get; set; }
    }
}
