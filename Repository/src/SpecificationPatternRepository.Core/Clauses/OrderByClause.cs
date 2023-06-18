using SpecificationPatternRepository.Core.Types;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Clauses
{
    public class OrderByClause<T>
    {
        public Expression<Func<T, object>> Expression { get; set; }
        public OrderByType OrderType { get; set; }

        public Func<T, object> KeySelectorFunc => keySelectorFunc.Value;
        private readonly Lazy<Func<T, object>> keySelectorFunc;

        public OrderByClause(Expression<Func<T, object>> expression, OrderByType type)
        {
            Expression = expression;
            OrderType = type;
            keySelectorFunc = new Lazy<Func<T, object>>(Expression.Compile());
        }
    }
}
