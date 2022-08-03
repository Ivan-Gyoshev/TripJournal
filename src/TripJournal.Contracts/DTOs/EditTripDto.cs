namespace TripJournal.Contracts.DTOs
{
    public class EditTripDto
    {
        public EditTripDto(string title, string description, string location, string type, int tripId)
        {
            TripId = tripId;
            Title = title;
            Description = description;
            Location = location;
            Type = type;
        }

        public int TripId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Location { get; private set; }

        public string Type { get; private set; }
    }
}
