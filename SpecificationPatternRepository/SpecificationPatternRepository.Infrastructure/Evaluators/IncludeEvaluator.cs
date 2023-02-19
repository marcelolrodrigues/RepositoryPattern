using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class IncludeEvaluator<T> : IEvaluator<T>
    {
        public static IncludeEvaluator<T> Instance { get; } = new IncludeEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            //foreach (var includeExpression in specification.IncludeExpressions)
            //{
            //    query = query.Include(includeExpression);
            //}
            return query;
        }
    }
}
