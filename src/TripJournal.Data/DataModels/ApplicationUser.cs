using Microsoft.AspNetCore.Identity;
using TripJournal.Contracts.Entities;

namespace TripJournal.Data.DataModels
{
    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
