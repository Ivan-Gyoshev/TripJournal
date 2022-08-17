namespace TripJournal.Web.Controllers.Trips.Models.ResponseModel
{
    public class AllTripsResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }
    }
}
