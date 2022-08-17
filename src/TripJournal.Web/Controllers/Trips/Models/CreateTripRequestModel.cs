namespace TripJournal.Web.Controllers.Trips.Models
{
    public class CreateTripRequestModel
    {
        public string User { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Type { get; set; }
    }
}
