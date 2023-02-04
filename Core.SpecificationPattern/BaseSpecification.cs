using Core.SpecificationPattern.Expressions;
using System.Linq.Expressions;

namespace Core.SpecificationPattern
{
    public class BaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; private set; }
        public List<OrderExpression<T>> OrderByExpressions { get; private set; }

        public BaseSpecification<T> Where(List<Expression<Func<T, bool>>> expression)
        {
            WhereExpressions = expression;
            return this;
        }

        public BaseSpecification<T> OrderBy(List<OrderExpression<T>> OrderExpressions)
        {
            OrderByExpressions = OrderExpressions;
            return this;
        }
    }
}
