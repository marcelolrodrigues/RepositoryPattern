using BaseRepository.Core;

namespace Core.SpecificationPattern.Interfaces
{
    public interface ISpecificationRepository<T> : IBaseRepository<T>
    {
        Task<List<T>> ListWithSpecification(IBaseSpecification<T> specification);
    }
}
