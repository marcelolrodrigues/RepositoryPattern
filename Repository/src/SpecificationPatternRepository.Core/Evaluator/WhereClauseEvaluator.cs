using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class WhereClauseEvaluator<T> : IEvaluator<T>, IInMemoryEvaluator<T>
    {
        public static WhereClauseEvaluator<T> Instance { get; } = new WhereClauseEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                query = query.Where(clause.Expression);
            return query;
        }

        public IEnumerable<T> Evaluate(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                set = set.Where(clause.WhereFunc);
            return set;
        }
    }
}
