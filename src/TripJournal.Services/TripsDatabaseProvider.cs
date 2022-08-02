using Microsoft.EntityFrameworkCore;
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

        public async Task<Trip> GetTripById(int id)
        {
            var trip = await _tripsRepository.GetAll()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return trip;
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            List<Trip> trips = await _tripsRepository.GetAll().ToListAsync().ConfigureAwait(false);
            return trips;
        }

        public async Task<List<Trip>> GetAllTripsForUser(string userId)
        {
            List<Trip> trips = await _tripsRepository.GetAll()
                .Where(t => t.CreatorId.Equals(userId))
                .ToListAsync()
                .ConfigureAwait(false);

            return trips;
        }

        public async Task<bool> SoftDeleteTrip(int tripId)
        {
            var trip = await GetTripById(tripId).ConfigureAwait(false);

            if (trip is null)
            {
                return false;
            }

            trip.IsDeleted = true;
            trip.DeletedOn = DateTime.UtcNow;

            await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
