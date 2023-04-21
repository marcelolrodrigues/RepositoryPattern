using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class InMemorySpecificationEvaluator
    {
        public static InMemorySpecificationEvaluator Instance { get; } = new InMemorySpecificationEvaluator();
        private List<IInMemoryEvaluator> Evaluators { get; }

        public InMemorySpecificationEvaluator()
        {
            Evaluators = new List<IInMemoryEvaluator>()
            {
                WhereClauseEvaluator.Instance,
                PaginationEvaluator.Instance,
            };
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (IInMemoryEvaluator eval in Evaluators)
                set = eval.Evaluate(set, specification);
            return set;
        }
    }
}
