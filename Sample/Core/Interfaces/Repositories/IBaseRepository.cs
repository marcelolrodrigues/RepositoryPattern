namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);

        Task<T> Read(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
