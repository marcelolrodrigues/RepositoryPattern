namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);

        Task<T?> GetById<TId>(TId entityId) where TId : notnull;

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
