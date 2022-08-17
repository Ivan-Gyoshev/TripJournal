using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TripJournal.Services;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [Route("Trips")]
    public class DeleteTripController : AuthorizedApiController
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public DeleteTripController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpPost, Route("Delete")]
        public async Task<IActionResult> DeleteTrip([FromQuery, Required] int id)
        {
            var result = await _tripsProvider.SoftDeleteTrip(id).ConfigureAwait(false);

            if (result is false)
            {
                return NotFound();
            }

            return Ok(id);
        }
    }
}
