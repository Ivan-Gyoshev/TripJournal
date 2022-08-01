using Microsoft.AspNetCore.Mvc;
using TripJournal.Contracts;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly TripsDatabaseProvider _databaseProvider;

        public TripController(TripsDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTripRequestModel model)
        {
            var dto = new CreateTripDTO(model.CreatorUserId, model.Title, model.Location, model.Description, model.Price, model.Type, model.StartDate, model.DueDate);

            await _databaseProvider.CreateTripAsync(dto).ConfigureAwait(false);

            return Accepted();
        }
    }
}
