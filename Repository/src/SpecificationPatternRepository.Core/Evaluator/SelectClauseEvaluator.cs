using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class SelectClauseEvaluator<T, TResult> : IInMemoryEvaluator<T, TResult>
    {
        public static SelectClauseEvaluator<T, TResult> Instance { get; } = new SelectClauseEvaluator<T, TResult>();

        public IEnumerable<TResult> Evaluate(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            IEnumerable<TResult> outputQuery = set.Select(specification.SelectorClause.Expression.Compile());
            return outputQuery;
        }

        public IQueryable<TResult> GetQuery(IQueryable<T> query, IBaseSpecification<T, TResult> specification)
        {
            IQueryable<TResult> outputQuery = query.Select(specification.SelectorClause.Expression);
            return outputQuery;
        }
    }
}
