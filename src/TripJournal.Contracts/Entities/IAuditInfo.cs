namespace TripJournal.Contracts.Entities
{
    public interface IAuditInfo
    {
        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset? ModifiedOn { get; set; }
    }
}
