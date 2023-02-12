using Core.SpecificationPattern.Expressions;
using System.Linq.Expressions;

namespace Core.SpecificationPattern.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; }
        public List<OrderExpression<T>> OrderByExpressions { get; }

        public BaseSpecification<T> Where(List<Expression<Func<T, bool>>> expression);
        public BaseSpecification<T> OrderBy(List<OrderExpression<T>> OrderExpressions);
    }
}
