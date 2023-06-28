using SpecificationPatternRepository.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternRepository.Core.Evaluator;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class AsNoTrackingEvaluator : IEvaluator
    {
        public static AsNoTrackingEvaluator Instance { get; } = new AsNoTrackingEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification) where T : class 
        {
            if(specification.AsNoTracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
