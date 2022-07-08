using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts;
using TripJournal.Contracts.Repositories;
using TripJournal.Data;
using TripJournal.Data.DataModels;
using TripJournal.Data.Repositories;

namespace TripJournal.Web
{
    public class StartUp
    {
        private readonly IConfiguration configuration;

        public StartUp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(UserCredentialsOptionsProvider.GetUserCredentialsOptions)
                    .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            /// Scoped
            services.AddScoped(typeof(IDeletableEfRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();
        }

        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
        }
    }
}
