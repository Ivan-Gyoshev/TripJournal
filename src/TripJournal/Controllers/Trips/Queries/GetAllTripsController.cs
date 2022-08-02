using Microsoft.AspNetCore.Mvc;
using TripJournal.Services;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [ApiController, Route("Trips")]
    public class GetAllTripsController : ControllerBase
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public GetAllTripsController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpGet, Route("All")]
        public async Task<IActionResult> GetAllTrips()
        {
            var trips = await _tripsProvider.GetAllTripsAsync().ConfigureAwait(false);

            return Ok(trips);
        }
    }
}
