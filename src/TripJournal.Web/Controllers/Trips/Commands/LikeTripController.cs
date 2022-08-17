using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models.RequestModels;
using TripJournal.Web.Controllers.Trips.Models.ResponseModel;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [Route("Trips")]
    public class LikeTripController : AuthorizedApiController
    {
        private readonly TripsDatabaseProvider _tripsDatabaseProvider;

        public LikeTripController(TripsDatabaseProvider tripsDatabaseProvider)
        {
            _tripsDatabaseProvider = tripsDatabaseProvider;
        }

        [HttpGet, Route("LikeForUser")]
        public IActionResult LikeForUser(int tripId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var hasLiked = _tripsDatabaseProvider.HasUserLikedTrip(tripId, userId);

            return Ok(hasLiked);
        }

        [HttpGet, Route("TripLikes")]
        public IActionResult TripLikes(int tripId)
        {
            var count = _tripsDatabaseProvider.GetTripLikesCount(tripId);

            return Ok(count);
        }

        [HttpPost, Route("Like")]
        public async Task<IActionResult> LikeTrip([FromBody] TripLikeRequestModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _tripsDatabaseProvider.SetTripAsLikedAsync(model.Id, userId).ConfigureAwait(false);

            return Accepted();
        }

        [HttpPost, Route("Unlike")]
        public async Task<IActionResult> UnlikeTrip([FromBody] TripLikeRequestModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _tripsDatabaseProvider.RemoveTripLikeAsync(model.Id, userId).ConfigureAwait(false);

            return Accepted();
        }
    }
}
