namespace TripJournal.Web.Controllers.Trips.Models.ResponseModel
{
    public class TripDetailsResponseModel
    {
        public TripDetailsResponseModel(int id, string creatorId, string title, string location, string type, string description, string imageUrl, int likesCount)
        {
            Id = id;
            CreatorId = creatorId;
            Title = title;
            Location = location;
            Type = type;
            Description = description;
            ImageUrl = imageUrl;
            LikesCount = likesCount;
        }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int LikesCount { get; set; }
    }
}
