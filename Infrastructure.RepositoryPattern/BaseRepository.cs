using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryPattern
{
    public class BaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _set;

        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._set = dbContext.Set<T>();
        }

        // create
        public async Task<T> Create(T entity) 
        {
            await _set.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        // read
        public async Task<T> Read(T entity)
        {
            return entity;
        }

        // update
        public async Task<T> Update(T entity)
        {
            return entity;
        }

        // delete
        public async Task<T> Delete(T entity)
        {
            return entity;
        }

        // SaveChanges
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
