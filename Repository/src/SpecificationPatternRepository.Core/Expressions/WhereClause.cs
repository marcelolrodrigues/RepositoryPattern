using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class WhereClause<T>
    {
        public Expression<Func<T, bool>> Expression { get; }
        
        private readonly Lazy<Func<T, bool>> _whereFunc;
        public Func<T, bool> WhereFunc => this._whereFunc.Value;

        public WhereClause(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
            _whereFunc = new Lazy<Func<T, bool>>(expression.Compile);
        }
    }
}
