using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class WhereClauseEvaluator : IEvaluator, IInMemoryEvaluatorOfT
    {
        public static WhereClauseEvaluator Instance { get; } = new WhereClauseEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                query = query.Where(clause.Expression);
            return query;
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                set = set.Where(clause.WhereFunc);
            return set;
        }
    }
}
