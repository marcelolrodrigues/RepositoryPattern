using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; private set; }
        public List<OrderExpression<T>> OrderByExpressions { get; private set; }
        public List<IncludeExpression> IncludeExpressions { get; private set; }

        public BaseSpecification<T> Where(List<Expression<Func<T, bool>>> expression)
        {
            WhereExpressions = expression;
            return this;
        }

        public BaseSpecification<T> OrderBy(List<OrderExpression<T>> orderExpressions)
        {
            OrderByExpressions = orderExpressions;
            return this;
        }

        public BaseSpecification<T> Include(List<IncludeExpression> includeExpressions)
        {
            IncludeExpressions = includeExpressions;
            return this;
        }
    }
}
