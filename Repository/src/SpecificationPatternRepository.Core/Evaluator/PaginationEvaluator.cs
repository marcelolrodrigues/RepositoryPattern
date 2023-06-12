using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class PaginationEvaluator : IInMemoryEvaluatorOfT
    {
        public static PaginationEvaluator Instance { get; } = new PaginationEvaluator();

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            if (specification.Skip != null && specification.Skip != 0)
                set = set.Skip(specification.Skip.Value);

            if (specification.Take != null)
                set = set.Take(specification.Take.Value);

            return set;
        }
    }
}
