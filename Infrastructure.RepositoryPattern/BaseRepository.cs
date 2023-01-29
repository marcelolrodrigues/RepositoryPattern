using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryPattern
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _set;

        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._set = dbContext.Set<T>();
        }

        #region CRUD

        public async Task<T> CreateAsync(T entity) 
        {
            await _set.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetByIdAsync<TId>(TId entityId) where TId : notnull
        {
            T? entity = await _set.FindAsync(entityId);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _set.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        // delete
        public async Task<T> DeleteAsync(T entity)
        {
            return entity;
        }

        #endregion

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
