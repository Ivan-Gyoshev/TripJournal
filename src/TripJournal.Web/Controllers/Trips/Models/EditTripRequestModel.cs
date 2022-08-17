namespace TripJournal.Web.Controllers.Trips.Models
{
    public class EditTripRequestModel
    {
        public int TripId { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
