using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class SelectorClause<T, TResult>
    {
        public Expression<Func<T, TResult>> Expression { get; set; }

        public SelectorClause(Expression<Func<T, TResult>> expression)
        {
            Expression = expression;
        }
    }
}
