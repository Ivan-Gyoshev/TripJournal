using TripJournal.Contracts;
using TripJournal.Contracts.Repositories;
using TripJournal.Data;
using TripJournal.Data.DataModels;
using TripJournal.Data.Repositories;

namespace TripJournal.Services
{
    public class TripsDatabaseProvider
    {
        private readonly IDeletableEfRepository<Trip> _tripsRepository;

        public TripsDatabaseProvider(IDeletableEfRepository<Trip> tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        public async Task CreateTripAsync(CreateTripDTO model)
        {
            Enum.TryParse(model.Type, out TripType type);

            var trip = new Trip
            {
                CreatorId = model.CreatorId,
                Title = model.Title,
                Location = model.Location,
                Description = model.Description,
                Price = model.Price,
                Type = type,
                StartDate = model.StartDate,
                DueDate = model.DueDate,
            };

            await _tripsRepository.AddAsync(trip).ConfigureAwait(false);
            await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
