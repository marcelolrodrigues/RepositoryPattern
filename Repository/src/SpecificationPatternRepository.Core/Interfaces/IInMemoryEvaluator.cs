namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IInMemoryEvaluator<T>
    {
        IEnumerable<T> Evaluate(IEnumerable<T> set, IBaseSpecification<T> specification);
    }

    public interface IInMemoryEvaluator<T, TResult>
    {
        IEnumerable<TResult> Evaluate(IEnumerable<T> set, IBaseSpecification<T, TResult> specification);
    }
}
