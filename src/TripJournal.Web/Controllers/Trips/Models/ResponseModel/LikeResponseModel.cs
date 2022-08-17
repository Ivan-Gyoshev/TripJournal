namespace TripJournal.Web.Controllers.Trips.Models.ResponseModel
{
    public class LikeResponseModel
    {
        public LikeResponseModel(string userId, int tripId)
        {
            UserId = userId;
            TripId = tripId;
        }

        public string UserId { get; set; }

        public int TripId { get; set; }
    }
}
