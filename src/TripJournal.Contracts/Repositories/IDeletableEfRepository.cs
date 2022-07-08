using TripJournal.Contracts.Entities;

namespace TripJournal.Contracts.Repositories
{
    public interface IDeletableEfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNotTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
