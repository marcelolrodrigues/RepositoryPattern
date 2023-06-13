using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Clauses
{
    public class SelectorClause<T, TResult>
    {
        public Expression<Func<T, TResult>> Expression { get; }
        
        private readonly Lazy<Func<T, TResult>> _func;
        public Func<T, TResult> Func => _func.Value;

        public SelectorClause(Expression<Func<T, TResult>> expression)
        {
            Expression = expression;
            _func = new Lazy<Func<T, TResult>>(expression.Compile());
        }
    }
}
