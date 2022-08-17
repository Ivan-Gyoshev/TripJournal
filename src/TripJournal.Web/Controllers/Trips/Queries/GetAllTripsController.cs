using Microsoft.AspNetCore.Mvc;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models.ResponseModel;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [Route("Trips")]
    public class GetAllTripsController : ApiControllerBase
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

            List<AllTripsResponseModel> result = trips.Select(trip => new AllTripsResponseModel
            {
                Id  = trip.Id,
                Title = trip.Title,
                Description = trip.Description,
                ImageUrl = trip.ImageUrl,
                Location = trip.Location,
                Type = trip.Type.ToString()
            })
            .OrderBy(x => x.Title)
            .ToList();

            return Ok(result);
        }
    }
}
