using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; set; }
        public List<OrderExpression<T>> OrderByExpressions { get; set; }
        public List<IncludeExpression> IncludeExpressions { get; set; }

        public SpecificationBuilder<T> SpecificationBuilder { get; }
        
        public BaseSpecification()
        {
            WhereExpressions = new List<Expression<Func<T, bool>>>();
            OrderByExpressions = new List<OrderExpression<T>>();
            IncludeExpressions = new List<IncludeExpression>();
            SpecificationBuilder = new SpecificationBuilder<T>(this);
        }
    }
}
