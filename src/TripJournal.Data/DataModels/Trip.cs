namespace TripJournal.Data.DataModels
{
    public class Trip
    {
        public Trip()
        {
            Participants = new List<ApplicationUser>();
        }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public TripType Type { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public List<ApplicationUser> Participants { get; set; }
    }
}
