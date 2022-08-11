﻿using TripJournal.Contracts.Entities;

namespace TripJournal.Data.DataModels
{
    public class Trip : BaseDeletableModel<int>
    {
        public Trip()
        {
            Participants = new List<ApplicationUser>();
        }

        public string CreatorId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public TripType Type { get; set; }

        public List<ApplicationUser> Participants { get; set; }
    }
}
