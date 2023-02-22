namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IInMemoryEvaluator
    {
        IEnumerable<T> Evaluate<T>(IEnumerable<T> query, IBaseSpecification<T> specification);
    }
}
