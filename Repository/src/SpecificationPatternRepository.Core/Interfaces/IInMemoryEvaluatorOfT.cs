namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IInMemoryEvaluatorOfT
    {
        IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification);
    }

    public interface IInMemoryEvaluatorOfTAndTResult
    {
        IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> set, IBaseSpecification<T, TResult> specification);
    }    
}
