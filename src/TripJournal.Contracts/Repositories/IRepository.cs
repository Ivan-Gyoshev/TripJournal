namespace TripJournal.Contracts.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> AllAsNoTracking();

        Task<int> SaveChangesAsync();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
