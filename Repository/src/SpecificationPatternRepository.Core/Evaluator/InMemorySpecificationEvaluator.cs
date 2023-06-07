using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class InMemorySpecificationEvaluator
    {
        public static InMemorySpecificationEvaluator Instance { get; } = new InMemorySpecificationEvaluator();
        private List<IInMemoryEvaluator> _inMemoryEvaluators { get; }

        public InMemorySpecificationEvaluator()
        {
            _inMemoryEvaluators = new List<IInMemoryEvaluator>()
            {
                WhereClauseEvaluator.Instance,
                OrderByClauseEvaluator.Instance,
                PaginationEvaluator.Instance,
            };
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (IInMemoryEvaluator inMemoryEvaluators in _inMemoryEvaluators)
                set = inMemoryEvaluators.Evaluate(set, specification);
            return set;
        }

        public IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            foreach (IInMemoryEvaluator eval in _inMemoryEvaluators)
                set = eval.Evaluate(set, specification);

            IEnumerable<TResult> result = set.Select(specification.SelectorClause.Expression.Compile());

            return result;
        }
    }
}
