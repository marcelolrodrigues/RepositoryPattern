using Core.SpecificationPattern.Interfaces;

namespace SpecificationRepository.Infrastructure.Evaluators
{
    public class WhereEvaluator<T> : IEvaluator<T>
    {
        public static WhereEvaluator<T> Instance { get; } = new WhereEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (var where in specification.WhereExpressions)
                query = query.Where(where);
            return query;
        }
    }
}
