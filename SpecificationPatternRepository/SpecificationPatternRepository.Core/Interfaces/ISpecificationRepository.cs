using BaseRepository.Core;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface ISpecificationRepository<T> : IBaseRepository<T>
    {
        Task<List<T>> ListWithSpecification(IBaseSpecification<T> specification);
    }
}
