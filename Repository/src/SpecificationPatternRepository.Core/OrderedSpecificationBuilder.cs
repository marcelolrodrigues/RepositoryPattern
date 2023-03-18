using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class OrderedSpecificationBuilder<T>
    {
        private BaseSpecification<T> BaseSpecification { get; }

        public OrderedSpecificationBuilder(BaseSpecification<T> baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public OrderedSpecificationBuilder<T> ThenBy(Expression<Func<T, object>> orderExpression)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpression,
                    OrderType = OrderByType.ThenBy
                }
            );
            return this;
        }


        public OrderedSpecificationBuilder<T> ThenByDescending(Expression<Func<T, object>> orderExpression)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpression,
                    OrderType = OrderByType.ThenByDescending
                }
            );
            return this;
        }
    }
}
