using System.Linq.Expressions;

namespace Core.SpecificationPattern.Expressions
{
    public class OrderExpression<T>
    {
        public Expression<Func<T, object>> OrderByExpression { get; set; }
        public OrderBy OrderBy { get; set; }
    }

    public enum OrderBy
    {
        Ascending,
        Descending
    }
}
