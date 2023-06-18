using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Interfaces;
using SpecificationPatternRepository.Infrastructure.Evaluators;

namespace SpecificationPatternRepository.Infrastructure
{
    public class SpecificationEvaluator 
    {
        public static SpecificationEvaluator Instance { get; } = new SpecificationEvaluator();
        private readonly List<IEvaluator> _evaluators;

        public SpecificationEvaluator()
        {
            _evaluators = new List<IEvaluator>()
            {
                WhereClauseEvaluator.Instance,
                OrderByClauseEvaluator.Instance,
                IncludeEvaluator.Instance,
            };
        }

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification) where T : class
        {
            foreach (IEvaluator evaluator in _evaluators)
                query = evaluator.GetQuery(query, specification);
            return query;
        }
    }
}
