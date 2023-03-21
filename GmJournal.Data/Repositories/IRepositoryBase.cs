using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GmJournal.Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsByIdAsync(long id);

        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(long id);
        Task DeleteAsync(TEntity entity);

        Task SaveChangesAsync();
    }
}
