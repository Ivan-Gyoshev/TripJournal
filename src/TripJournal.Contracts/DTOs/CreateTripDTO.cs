namespace TripJournal.Contracts.DTOs
{
    public class CreateTripDTO
    {
        public CreateTripDTO(string creatorId, string title, string location, string description, string imageUrl, string type)
        {
            CreatorId = creatorId;
            Title = title;
            Location = location;
            Description = description;
            ImageUrl = imageUrl;
            Type = type;
        }

        public string CreatorId { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        public string Type { get; private set; }
    }
}