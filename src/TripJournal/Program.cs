using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts;
using TripJournal.Contracts.Repositories;
using TripJournal.Data;
using TripJournal.Data.DataModels;
using TripJournal.Data.Repositories;

namespace TripJournal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /// Initializing application builder
            var builder = WebApplication.CreateBuilder(args);

            /// Service Registration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(UserCredentialsOptionsProvider.GetUserCredentialsOptions)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            /// Scoped
            builder.Services.AddScoped(typeof(IDeletableEfRepository<>), typeof(EfDeletableEntityRepository<>));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            var app = builder.Build();

            /// Configure the HTTP request pipeline. (middlewares)
            if (app.Environment.IsDevelopment())
                app.UseMigrationsEndPoint();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}