using Microsoft.AspNetCore.Mvc;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [Route("Trip")]
    public class CreateTripController : ControllerBase
    {
        [HttpPost, Route("Create")]
        public IActionResult CreateTrip()
        {
            return Ok();
        }
    }
}
