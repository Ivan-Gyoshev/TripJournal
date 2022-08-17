using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TripJournal.Contracts;
using TripJournal.Contracts.Repositories;
using TripJournal.Data;
using TripJournal.Data.DataModels;
using TripJournal.Data.Repositories;
using TripJournal.Services;

namespace TripJournal.Web
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /// Service Registration
            var connectionString = Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<ApplicationUser>(UserCredentialsOptionsProvider.GetUserCredentialsOptions)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();


            services.AddCors();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddRazorPages();

            /// Scoped
            services.AddScoped(typeof(IDeletableEfRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            /// Transient
            services.AddTransient<TripsDatabaseProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.ConfigureCors();

            app.UseForwardedHeaders();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }

    public static class CorsExtensions
    {
        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            IConfiguration configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();

            var headers = new string[]
            {
                "Accept",
                "Content-Type",
                "Origin",
                "Authorization"
            };

            var methods = new string[]
            {
                "GET",
                "PUT",
                "POST",
                "DELETE",
                "OPTIONS"
            };

            var origins = new string[]
            {
                "https://localhost:44413"
            };

            app.UseCors(builder =>
            {
                if (headers is null == false) builder.WithHeaders(headers);
                if (methods is null == false) builder.WithMethods(methods);
                if (origins is null == false) builder.WithOrigins(origins);
            });

            return app;
        }
    }
}
