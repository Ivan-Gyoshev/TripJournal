using Microsoft.AspNetCore.Mvc;
using TripJournal.Contracts;
using TripJournal.Contracts.DTOs;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [ApiController, Route("Trips")]

    public class CreateTripController : ControllerBase
    {
        private readonly TripsDatabaseProvider _databaseProvider;

        public CreateTripController(TripsDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTripRequestModel model)
        {
            var dto = new CreateTripDTO(model.UserId, model.Title, model.Location, model.Description, model.Price, model.Type);

            var trip = await _databaseProvider.CreateTripAsync(dto).ConfigureAwait(false);

            return Accepted(trip);
        }
    }
}
