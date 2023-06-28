using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class LikeEvaluator : IInMemoryEvaluatorOfT
    {
        public static LikeEvaluator Instance { get; } = new LikeEvaluator();

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (IGrouping<int, LikeClause<T>> likeGroup in specification.LikeClauses.GroupBy(x => x.LikeGroup))
                set = set.Where(setItem => likeGroup.Any(likeClause => likeClause.LikeFunc(setItem).Like(likeClause.LikeTerm)));
            return set;
        }
    }
}
