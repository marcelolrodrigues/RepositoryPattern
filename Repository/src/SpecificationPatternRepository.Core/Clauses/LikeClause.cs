using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Clauses
{
    public class LikeClause<T>
    {
        public Expression<Func<T, string>> Expression { get; set; }
        
        private readonly Lazy<Func<T, string>> _likeFunc;
        public Func<T, string> LikeFunc => _likeFunc.Value;

        public string LikeTerm { get; set; }
        public int LikeGroup { get; set; }

        public LikeClause(Expression<Func<T, string>> expression, string searchItem, int likeGroup)
        {
            Expression = expression;
            _likeFunc = new Lazy<Func<T, string>>(expression.Compile());
            LikeTerm = searchItem;
            LikeGroup = likeGroup;
        }
    }
}