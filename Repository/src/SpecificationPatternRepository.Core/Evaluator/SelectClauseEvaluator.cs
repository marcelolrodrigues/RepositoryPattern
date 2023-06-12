using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class SelectClauseEvaluator : IInMemoryEvaluatorOfTAndTResult
    {
        public static SelectClauseEvaluator Instance { get; } = new SelectClauseEvaluator();

        public IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            IEnumerable<TResult> outputQuery = set.Select(specification.SelectorClause.Expression.Compile());
            return outputQuery;
        }

        public IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> query, IBaseSpecification<T, TResult> specification)
        {
            IQueryable<TResult> outputQuery = query.Select(specification.SelectorClause.Expression);
            return outputQuery;
        }
    }
}
