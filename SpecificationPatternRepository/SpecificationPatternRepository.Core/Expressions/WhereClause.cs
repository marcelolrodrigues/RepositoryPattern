using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class WhereClause<T>
    {
        public Expression<Func<T, bool>> WhereExpression { get; }
        
        private readonly Lazy<Func<T, bool>> _whereFunc;
        public Func<T, bool> WhereFunc => this._whereFunc.Value;

        public WhereClause(Expression<Func<T, bool>> whereExpression)
        {
            WhereExpression = whereExpression;
            _whereFunc = new Lazy<Func<T, bool>>(whereExpression.Compile);
        }
    }
}
