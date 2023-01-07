using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryPattern
{
    public class BaseRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // create
        public async Task<T> Create(T entity) 
        {
            await dbContext.Set<T>().AddAsync(entity);
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
            await dbContext.SaveChangesAsync();
        }
    }
}
