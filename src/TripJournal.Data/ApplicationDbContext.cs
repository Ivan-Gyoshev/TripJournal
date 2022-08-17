using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using TripJournal.Contracts.Entities;
using TripJournal.Data.DataModels;

namespace TripJournal.Data
{

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterAction = typeof(ApplicationDbContext)
            .GetMethod(nameof(SetIsDeletedFilter), BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Like> Likes { get; set; }

        public override int SaveChanges() => base.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Required for Identity Models configurations
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Sets a global query filter for non-deleted entities only
            var deletableEntityTypes = entityTypes
               .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntity in deletableEntityTypes)
            {
                var action = SetIsDeletedQueryFilterAction.MakeGenericMethod(deletableEntity.ClrType);
                action.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete

            var foreignKeys = entityTypes.SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var key in foreignKeys)
                key.DeleteBehavior = DeleteBehavior.Restrict;

        }

        private static void SetIsDeletedFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.IsDeleted == false);
        }

        private void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntires = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntires)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                    entity.CreatedOn = DateTimeOffset.UtcNow;
                else
                    entity.ModifiedOn = DateTimeOffset.UtcNow;
            }
        }
    }
}
