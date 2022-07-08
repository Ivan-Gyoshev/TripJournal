using Microsoft.AspNetCore.Identity;

namespace TripJournal.Data
{
    public static class UserCredentialsOptionsProvider
    {
        public static void GetUserCredentialsOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        }
    }
}
