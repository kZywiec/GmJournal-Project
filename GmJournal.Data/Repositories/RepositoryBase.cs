using Microsoft.EntityFrameworkCore;
using GmJournal.Data.Configuration;
using System.Linq.Expressions;

namespace GmJournal.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly GmJournalDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(GmJournalDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
        }



        public async virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _dbContext
                .Set<TEntity>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async virtual Task<bool> ExistsByIdAsync(long id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async virtual Task<TEntity> GetByIdAsync(long id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
            
            if (entity == null)
                throw new Exception($"Object of type {typeof(TEntity)} with id {id} not found.");

            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
        }

        public async virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public async virtual Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}