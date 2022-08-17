using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts.DTOs;
using TripJournal.Contracts.Repositories;
using TripJournal.Data;
using TripJournal.Data.DataModels;
using TripJournal.Data.Repositories;

namespace TripJournal.Services
{
    public class TripsDatabaseProvider
    {
        private readonly IDeletableEfRepository<Trip> _tripsRepository;
        private readonly IRepository<Like> _likesRepository;

        public TripsDatabaseProvider(IDeletableEfRepository<Trip> tripsRepository, IRepository<Like> likesRepository)
        {
            _tripsRepository = tripsRepository;
            _likesRepository = likesRepository;
        }

        public async Task<int> CreateTripAsync(CreateTripDTO model)
        {
            Enum.TryParse(model.Type, true, out TripType type);

            var trip = new Trip
            {
                CreatorId = model.CreatorId,
                Title = model.Title,
                Location = model.Location,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Type = type
            };

            await _tripsRepository.AddAsync(trip).ConfigureAwait(false);
            await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);

            return trip.Id;
        }

        public async Task<int> EditTripAsync(EditTripDto trip)
        {
            var tripToEdit = await GetTripById(trip.TripId).ConfigureAwait(false);

            Enum.TryParse(trip.Type, true, out TripType type);

            tripToEdit.Title = trip.Title;
            tripToEdit.Description = trip.Description;
            tripToEdit.Location = trip.Location;
            tripToEdit.Type = type;

            await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);

            return trip.TripId;
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

        public async Task SetTripAsLikedAsync(int tripId, string userId)
        {
            Like like;

            like = await GetLike(userId, tripId).ConfigureAwait(false);
            if (like is null)
            {
                like = new Like(tripId, userId);
                await _likesRepository.AddAsync(like).ConfigureAwait(false);
                await _likesRepository.SaveChangesAsync().ConfigureAwait(false);

                var tripToLike = await GetTripById(tripId).ConfigureAwait(false);
                tripToLike.Likes.Add(like);

                await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task RemoveTripLikeAsync(int tripId, string userId)
        {
            var like = await GetLike(userId, tripId).ConfigureAwait(false);

            if (like is not null)
            {
                _likesRepository.Delete(like);
                await _likesRepository.SaveChangesAsync().ConfigureAwait(false);

                var tripToUnlike = await GetTripById(tripId).ConfigureAwait(false);
                tripToUnlike.Likes.Remove(like);

                await _tripsRepository.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public int GetTripLikesCount(int tripId)
        {
            var likes = _likesRepository.GetAll()
                .Where(x => x.TripId == tripId).ToList();

            return likes.Count;
        }

        public bool HasUserLikedTrip(int tripId, string userId)
        {
            var likes = _likesRepository.GetAll()
                 .Where(x => x.TripId == tripId).ToList();

            return likes.Where(x => x.UserId.Equals(userId)).Any();
        }

        public async Task<Like> GetLike(string userId, int tripId)
        {
            return await _likesRepository.GetAll()
                .Where(l => l.UserId.Equals(userId) && l.TripId == tripId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
