using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class OrderByClauseEvaluator<T> : IEvaluator<T>, IInMemoryEvaluator<T>
    {
        public static OrderByClauseEvaluator<T> Instance { get; } = new OrderByClauseEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            if (specification.OrderByClauses.Count == 0)
                return query;

            if(specification.OrderByClauses.Count(
                spec => spec.OrderType == OrderByType.OrderBy 
                || spec.OrderType == OrderByType.OrderByDescending
            ) > 1)
            {
                throw new DuplicateOrderChainException();
            }

            IOrderedQueryable<T>? orderedQuery = null;
            foreach (OrderByClause<T> orderExpression in specification.OrderByClauses)
            {
                if (orderExpression.OrderType == OrderByType.OrderBy)
                    orderedQuery = query.OrderBy(orderExpression.Expression);
                else if (orderExpression.OrderType == OrderByType.OrderByDescending)
                    orderedQuery = query.OrderByDescending(orderExpression.Expression);
                else if (orderExpression.OrderType == OrderByType.ThenBy)
                    orderedQuery = orderedQuery.ThenBy(orderExpression.Expression);
                else
                    orderedQuery = orderedQuery.ThenByDescending(orderExpression.Expression);
            }

            return orderedQuery;
        }

        public IEnumerable<T> Evaluate(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            if (specification.OrderByClauses.Count == 0)
                return set;

            if(specification.OrderByClauses.Count(
                spec => spec.OrderType == OrderByType.OrderBy 
                || spec.OrderType == OrderByType.OrderByDescending
            ) > 1)
            {
                throw new DuplicateOrderChainException();
            }

            IOrderedEnumerable<T>? orderedSet = null;
            foreach (OrderByClause<T> orderExpression in specification.OrderByClauses)
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
