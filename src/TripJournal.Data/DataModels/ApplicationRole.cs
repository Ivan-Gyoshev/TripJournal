using Microsoft.AspNetCore.Identity;
using TripJournal.Contracts.Entities;

namespace TripJournal.Data.DataModels
{
    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
        }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
