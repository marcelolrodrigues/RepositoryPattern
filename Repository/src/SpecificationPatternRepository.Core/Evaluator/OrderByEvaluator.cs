using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class OrderByEvaluator : IEvaluator, IInMemoryEvaluator
    {
        public static OrderByEvaluator Instance { get; } = new OrderByEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> spec)
        {
            if (spec.OrderByExpressions == null)
                return query;

            IOrderedQueryable<T>? orderedQuery = null;
            foreach (OrderExpression<T> orderExpression in spec.OrderByExpressions)
            {
                if (orderExpression.OrderType == OrderByType.OrderBy)
                    orderedQuery = query.OrderBy(orderExpression.OrderByExpression);
                else if (orderExpression.OrderType == OrderByType.OrderByDescending)
                    orderedQuery = query.OrderByDescending(orderExpression.OrderByExpression);
                else if (orderExpression.OrderType == OrderByType.ThenBy)
                    orderedQuery = orderedQuery.ThenBy(orderExpression.OrderByExpression);
                else
                    orderedQuery = orderedQuery.ThenByDescending(orderExpression.OrderByExpression);
            }

            return orderedQuery;
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            if (specification.OrderByExpressions == null) 
                return set;

            IOrderedEnumerable<T>? orderedSet = null;
            foreach (OrderExpression<T> orderExpression in specification.OrderByExpressions)
            {
                if (orderExpression.OrderType == OrderByType.OrderBy)
                    orderedSet = set.OrderBy(orderExpression.KeySelectorFunc);
                else if (orderExpression.OrderType == OrderByType.OrderByDescending)
                    orderedSet = set.OrderByDescending(orderExpression.KeySelectorFunc);
                else if (orderExpression.OrderType == OrderByType.ThenBy)
                    orderedSet = orderedSet.ThenBy(orderExpression.KeySelectorFunc);
                else
                    orderedSet = orderedSet.ThenByDescending(orderExpression.KeySelectorFunc);
            }

            return orderedSet;
        }
    }
}
