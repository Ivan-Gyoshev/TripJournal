using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripJournal.Contracts.DTOs;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [Route("Trips")]
    public class CreateTripController : AuthorizedApiController
    {
        private readonly TripsDatabaseProvider _databaseProvider;

        public CreateTripController(TripsDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTripRequestModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto = new CreateTripDTO(userId, model.Title, model.Location, model.Description, model.ImageUrl, model.Type);

            var trip = await _databaseProvider.CreateTripAsync(dto).ConfigureAwait(false);

            return Accepted(trip);
        }
    }
}
