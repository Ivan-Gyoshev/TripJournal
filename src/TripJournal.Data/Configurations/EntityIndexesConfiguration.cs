using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts.Entities;

namespace TripJournal.Data
{
    internal static class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // IDeletableEntity.IsDeleted Index
            var deletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType is not null && typeof(IDeletableEntity).IsAssignableFrom(e.ClrType));

            foreach (var entityType in deletableEntityTypes)
            {
                modelBuilder.Entity(entityType.ClrType).HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }
    }
}
