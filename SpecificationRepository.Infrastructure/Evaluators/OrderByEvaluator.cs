using Core.SpecificationPattern.Expressions;
using Core.SpecificationPattern.Interfaces;

namespace SpecificationRepository.Infrastructure.Evaluators
{
    public class OrderByEvaluator<T> : IEvaluator<T>
    {
        public static OrderByEvaluator<T> Instance { get; } = new OrderByEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> spec)
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
