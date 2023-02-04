using Core.SpecificationPattern;
using Core.SpecificationPattern.Evaluator;

namespace Infrastructure.RepositoryPattern.Evaluators
{
    public class WhereEvaluator : IEvaluator
    {
        public static WhereEvaluator Instance { get; } = new WhereEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, BaseSpecification<T> specification)
        {
            foreach (var where in specification.WhereExpressions)
                query = query.Where(where);
            return query;
        }
    }
}
