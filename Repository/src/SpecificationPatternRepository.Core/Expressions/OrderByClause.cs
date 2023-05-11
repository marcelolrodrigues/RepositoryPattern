using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class OrderByClause<T>
    {
        public Expression<Func<T, object>> Expression { get; set; }
        public OrderByType OrderType { get; set; }

        public Func<T, object?> KeySelectorFunc => this.keySelectorFunc.Value;
        private readonly Lazy<Func<T, object?>> keySelectorFunc;

        public OrderByClause(Expression<Func<T, object?>> expression, OrderByType type)
        {
            Expression = expression;
            OrderType = type;
            keySelectorFunc = new Lazy<Func<T, object?>>(this.Expression.Compile());
        }
    }

    public enum OrderByType
    {
        OrderBy,
        OrderByDescending,
        ThenBy,
        ThenByDescending
    }
}
