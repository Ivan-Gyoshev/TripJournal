using Microsoft.EntityFrameworkCore;
using TripJournal.Contracts.Entities;
using TripJournal.Contracts.Repositories;

namespace TripJournal.Data.Repositories
{
    public class EfDeletableEntityRepository<TEntity> : EfRepository<TEntity>, IDeletableEfRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public EfDeletableEntityRepository(ApplicationDbContext context, DbSet<TEntity> dbSet)
            : base(context, dbSet)
        {
        }

        public IQueryable<TEntity> AllAsNotTrackingWithDeleted()
        {
            return base.AllAsNoTracking().IgnoreQueryFilters();
        }

        public override IQueryable<TEntity> GetAll()
        {
            return base.GetAll().Where(x => x.IsDeleted == false);
        }

        public override IQueryable<TEntity> AllAsNoTracking()
        {
            return base.AllAsNoTracking().Where(x => x.IsDeleted == false);
        }

        public IQueryable<TEntity> AllWithDeleted()
        {
            return base.GetAll().IgnoreQueryFilters();
        }

        public void HardDelete(TEntity entity)
        {
            base.Delete(entity);
        }

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTimeOffset.UtcNow;
            Update(entity);
        }
    }
}
