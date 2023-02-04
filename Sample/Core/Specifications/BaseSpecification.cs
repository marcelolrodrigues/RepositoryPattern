using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; private set; }
        public List<Expression<Func<T, object>>> OrderByExpressions { get; private set; }

        public void Where(List<Expression<Func<T, bool>>> expression)
        {
            WhereExpressions = expression;
        }

        public void OrderBy(List<Expression<Func<T, object>>> expression)
        {
            OrderByExpressions = expression;
        }
    }
}
