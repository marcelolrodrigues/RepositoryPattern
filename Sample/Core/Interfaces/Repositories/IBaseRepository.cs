using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);

        Task<T?> GetByIdAsync<TId>(TId entityId) where TId : notnull;
        Task<List<T>> ListAsync();

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
