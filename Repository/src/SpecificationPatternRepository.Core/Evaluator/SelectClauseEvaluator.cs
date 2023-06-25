using SpecificationPatternRepository.Core.Interfaces;
using System.Linq;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class SelectClauseEvaluator : IInMemoryEvaluatorOfTAndTResult
    {
        public static SelectClauseEvaluator Instance { get; } = new SelectClauseEvaluator();

        public IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            IEnumerable<TResult> outputQuery = set.Select(specification.SelectClause.Func);
            return outputQuery;
        }

        public IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> query, IBaseSpecification<T, TResult> specification)
        {
            IQueryable<TResult> outputQuery = query.Select(specification.SelectClause.Expression);
            return outputQuery;
        }
    }
}
