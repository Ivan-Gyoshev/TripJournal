using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models.ResponseModel;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [Route("Trips")]
    public class GetTripsLikedByUserController : AuthorizedApiController
    {
        private readonly TripsDatabaseProvider tripsDatabaseProvider;

        public GetTripsLikedByUserController(TripsDatabaseProvider tripsDatabaseProvider)
        {
            this.tripsDatabaseProvider = tripsDatabaseProvider;
        }

        [Route("UserLikedTrips")]
        public async Task<IActionResult> GetUserLikedTrips()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var trips = await tripsDatabaseProvider.GetAllLikedTripsByUser(userId).ConfigureAwait(false);

            List<AllTripsResponseModel> result = trips.Select(trip => new AllTripsResponseModel
            {
                Id = trip.Id,
                Title = trip.Title,
                Description = trip.Description,
                ImageUrl = trip.ImageUrl,
                Location = trip.Location,
                CreatedOn = trip.CreatedOn.ToString("dd/MM/yyyy"),
                Type = trip.Type.ToString()
            })
            .OrderBy(x => x.Title)
            .ToList();

            return Ok(result);
        }
    }
}
