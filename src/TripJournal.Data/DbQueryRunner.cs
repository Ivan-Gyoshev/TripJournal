using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts;

namespace TripJournal.Data
{
    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(ApplicationDbContext db)
        {
            Context = db ?? throw new ArgumentNullException(nameof(db));
        }

        public ApplicationDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlRawAsync(query, parameters);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
