using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TripJournal.Web;

namespace TripJournal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplication.CreateBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<StartUp>();
                    });
    }
}
