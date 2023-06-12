using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class PaginationEvaluator<T> : IInMemoryEvaluator<T>
    {
        public static PaginationEvaluator<T> Instance { get; } = new PaginationEvaluator<T>();

        public IEnumerable<T> Evaluate(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            if (specification.Skip != null && specification.Skip != 0)
                set = set.Skip(specification.Skip.Value);

            if (specification.Take != null)
                set = set.Take(specification.Take.Value);

            return set;
        }
    }
}
