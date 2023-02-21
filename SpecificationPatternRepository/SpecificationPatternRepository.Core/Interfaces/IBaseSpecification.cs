using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; }
        public List<OrderExpression<T>> OrderByExpressions { get; }
        public List<IncludeExpression> IncludeExpressions { get; }

        public BaseSpecification<T> Where(List<Expression<Func<T, bool>>> expression);
        public BaseSpecification<T> OrderBy(List<OrderExpression<T>> OrderExpressions);
        public BaseSpecification<T> Include(List<IncludeExpression> includeExpressions);
    }
}
