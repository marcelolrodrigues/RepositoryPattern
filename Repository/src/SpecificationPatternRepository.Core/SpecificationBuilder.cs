using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class SpecificationBuilder<T>
    {
        private BaseSpecification<T> BaseSpecification { get; }

        public SpecificationBuilder(BaseSpecification<T> baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public SpecificationBuilder<T> Where(Expression<Func<T, bool>> expression)
        {
            BaseSpecification.WhereClauses.Add(new WhereClause<T>(expression));
            return this;
        }

        public OrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpressions,
                    OrderType = OrderByType.OrderBy
                }
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public OrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpressions,
                    OrderType = OrderByType.OrderByDescending
                }
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public SpecificationBuilder<T> Include(IncludeExpression includeExpressions)
        {
            BaseSpecification.IncludeExpressions.Add(includeExpressions);
            return this;
        }
    }
}
