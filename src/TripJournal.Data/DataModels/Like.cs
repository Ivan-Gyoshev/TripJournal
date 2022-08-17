using TripJournal.Contracts.Entities;

namespace TripJournal.Data.DataModels
{
    public class Like : BaseModel<int>
    {
        public Like(int tripId, string userId)
        {
            TripId = tripId;
            UserId = userId;
        }

        public string UserId { get; set; }

        public int TripId { get; set; }
    }
}
