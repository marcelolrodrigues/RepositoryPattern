using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class OrderByEvaluator : IEvaluator, IInMemoryEvaluator
    {
        public static OrderByEvaluator Instance { get; } = new OrderByEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            if (specification.OrderByExpressions.Count == 0)
                return query;

            if(specification.OrderByExpressions.Count(
                spec => spec.OrderType == OrderByType.OrderBy 
                || spec.OrderType == OrderByType.OrderByDescending
            ) > 1)
            {
                throw new DuplicateOrderChainException();
            }

            IOrderedQueryable<T>? orderedQuery = null;
            foreach (OrderExpression<T> orderExpression in specification.OrderByExpressions)
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
            if (specification.OrderByExpressions.Count == 0)
                return set;

            if(specification.OrderByExpressions.Count(
                spec => spec.OrderType == OrderByType.OrderBy 
                || spec.OrderType == OrderByType.OrderByDescending
            ) > 1)
            {
                throw new DuplicateOrderChainException();
            }

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
