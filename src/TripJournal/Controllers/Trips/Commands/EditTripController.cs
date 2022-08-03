﻿using Microsoft.AspNetCore.Mvc;
using TripJournal.Contracts.DTOs;
using TripJournal.Services;
using TripJournal.Web.Controllers.Trips.Models;

namespace TripJournal.Web.Controllers.Trips.Commands
{
    [ApiController, Route("Trips")]
    public class EditTripController : ControllerBase
    {
        private readonly TripsDatabaseProvider _tripsProvider;

        public EditTripController(TripsDatabaseProvider tripsProvider)
        {
            _tripsProvider = tripsProvider;
        }

        [HttpPost, Route("Edit")]
        public async Task<IActionResult> EditTrip([FromBody] EditTripRequestModel model)
        {
            var trip = await _tripsProvider.GetTripById(model.TripId).ConfigureAwait(false);

            if (trip.CreatorId.Equals(model.UserId) == false)
                return Forbid();

            var editDto = new EditTripDto(model.Title, model.Description, model.Location, model.Type, model.TripId);

            var editedTrip = await _tripsProvider.EditTripAsync(editDto).ConfigureAwait(false);

            return Accepted(editedTrip);
        }
    }
}