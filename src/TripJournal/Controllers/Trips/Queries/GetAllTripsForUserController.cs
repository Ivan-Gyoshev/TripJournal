using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TripJournal.Services;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [Route("Trips")]
    public class GetAllTripsForUserController : AuthorizedApiController
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public GetAllTripsForUserController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpGet, Route("UserTrips")]
        public async Task<IActionResult> GetTripsForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var trips = await _tripsProvider.GetAllTripsForUser(userId).ConfigureAwait(false);

            return Ok(trips);
        }
    }
}
