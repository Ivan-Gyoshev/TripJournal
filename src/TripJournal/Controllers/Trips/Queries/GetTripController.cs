using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models.ResponseModel;

namespace TripJournal.Web.Controllers.Trips.Queries
{
    [Route("Trips")]
    public class GetTripController : ApiControllerBase
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public GetTripController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpGet, Route("Details")]
        public async Task<IActionResult> GetTripDetails([FromQuery, Required] int id)
        {
            var trip = await _tripsProvider.GetTripById(id).ConfigureAwait(false);

            if (trip is null)
            {
                return NotFound();
            }

            var response = new TripDetailsResponseModel(trip.Id, trip.CreatorId, trip.Title, trip.Location, trip.Type.ToString(), trip.Description, trip.ImageUrl);

            return Ok(response);
        }
    }
}
