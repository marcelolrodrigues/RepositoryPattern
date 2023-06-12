using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class InMemorySpecificationEvaluator<T>
    {
        public static InMemorySpecificationEvaluator<T> Instance { get; } = new InMemorySpecificationEvaluator<T>();
        private List<IInMemoryEvaluator<T>> _inMemoryEvaluatorsOfT { get; }

        public InMemorySpecificationEvaluator()
        {
            _inMemoryEvaluatorsOfT = new List<IInMemoryEvaluator<T>>()
            {
                WhereClauseEvaluator<T>.Instance,
                OrderByClauseEvaluator<T>.Instance,
                PaginationEvaluator<T>.Instance
            };
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (IInMemoryEvaluator<T> inMemoryEvaluators in _inMemoryEvaluatorsOfT)
                set = inMemoryEvaluators.Evaluate(set, specification);
            return set;
        }
    }

    public class InMemorySpecificationEvaluator<T, TResult> : InMemorySpecificationEvaluator<T>
    {
        public static InMemorySpecificationEvaluator<T, TResult> Instance { get; } = new InMemorySpecificationEvaluator<T, TResult>();
        private List<IInMemoryEvaluator<T, TResult>> _inMemoryEvaluatorsOfTAndTResult { get; }

        public InMemorySpecificationEvaluator()
        {
            _inMemoryEvaluatorsOfTAndTResult = new List<IInMemoryEvaluator<T, TResult>>()
            {
                SelectClauseEvaluator<T, TResult>.Instance
            };
        }

        public IEnumerable<TResult> Evaluate(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            IEnumerable<TResult> resultSet;
            foreach (IInMemoryEvaluator<T, TResult> eval in _inMemoryEvaluatorsOfTAndTResult)
                resultSet = eval.Evaluate(set, specification);

            IEnumerable<TResult> result = set.Select(specification.SelectorClause.Expression.Compile());

            return result;
        }
    }
}
