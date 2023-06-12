using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public interface IInMemorySpecificationEvaluator
    {
        IEnumerable<T> Evaluate<T>(IEnumerable<T> source, IBaseSpecification<T> specification);
        IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> source, IBaseSpecification<T, TResult> specification);
    }
}
