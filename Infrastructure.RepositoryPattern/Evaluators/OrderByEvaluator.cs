using Core.SpecificationPattern;
using Core.SpecificationPattern.Evaluator;
using Core.SpecificationPattern.Expressions;

namespace Infrastructure.RepositoryPattern.Evaluators
{
    public class OrderByEvaluator : IEvaluator
    {
        public static OrderByEvaluator Instance { get; } = new OrderByEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, BaseSpecification<T> spec)
        {
            foreach (OrderExpression<T> orderExpression in spec.OrderByExpressions)
            {
                if (orderExpression.OrderBy == OrderBy.Ascending)
                    query = query.OrderBy(orderExpression.OrderByExpression);
                else if (orderExpression.OrderBy == OrderBy.Descending)
                    query = query.OrderByDescending(orderExpression.OrderByExpression);
            }
            return query;
        }
    }
}
