using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TripJournal.Services;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [ApiController, Route("Trips")]
    public class GetAllTripsForUserController : ControllerBase
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public GetAllTripsForUserController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpGet, Route("UserTrips")]
        public async Task<IActionResult> GetTripsForUser([FromQuery, Required] string userId)
        {
            var trips = await _tripsProvider.GetAllTripsForUser(userId).ConfigureAwait(false);

            return Ok(trips);
        }
    }
}
