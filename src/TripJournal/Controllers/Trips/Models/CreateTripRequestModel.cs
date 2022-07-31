namespace TripJournal.Web.Controllers.Trips.Models
{
    public class CreateTripRequestModel
    {
        public string CreatorUserId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset DueDate { get; set; }
    }
}
