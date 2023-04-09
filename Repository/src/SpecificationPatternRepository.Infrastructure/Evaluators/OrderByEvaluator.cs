﻿using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class OrderByEvaluator : IEvaluator
    {
        public static OrderByEvaluator Instance { get; } = new OrderByEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> spec)
        {
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
            query = orderedQuery ?? query;
            return query;
        }
    }
}
