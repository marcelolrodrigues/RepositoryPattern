using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class OrderExpression<T>
    {
        public Expression<Func<T, object>> OrderByExpression { get; set; }
        public OrderByType OrderType { get; set; }
    }

    public enum OrderByType
    {
        OrderBy,
        OrderByDescending,
        ThenBy,
        ThenByDescending
    }
}
