using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class OrderExpression<T>
    {
        public Expression<Func<T, object>> OrderByExpression { get; set; }
        public OrderByType OrderType { get; set; }

        public Func<T, object?> KeySelectorFunc => this.keySelectorFunc.Value;
        private readonly Lazy<Func<T, object?>> keySelectorFunc;

        public OrderExpression(Expression<Func<T, object?>> keySelector, OrderByType orderType)
        {
            OrderByExpression = keySelector;
            OrderType = orderType;
            keySelectorFunc = new Lazy<Func<T, object?>>(this.OrderByExpression.Compile());
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
