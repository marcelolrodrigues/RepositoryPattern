using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class WhereEvaluator<T> : IEvaluator<T>
    {
        public static WhereEvaluator<T> Instance { get; } = new WhereEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                query = query.Where(clause.WhereExpression);
            return query;
        }
    }
}
