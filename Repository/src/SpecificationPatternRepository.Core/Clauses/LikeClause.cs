using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Clauses
{
    public class LikeClause<T>
    {
        public Expression<Func<T, string>> Expression { get; set; }
        public string LikeTerm { get; set; }
        public int LikeGroup { get; set; }

        public LikeClause(Expression<Func<T, string>> expression, string searchItem, int likeGroup)
        {
            Expression = expression;
            LikeTerm = searchItem;
            LikeGroup = likeGroup;
        }
    }
}