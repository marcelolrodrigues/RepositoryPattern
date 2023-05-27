using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Interfaces;
using SpecificationPatternRepository.Infrastructure.Evaluators;

namespace SpecificationPatternRepository.Infrastructure
{
    public class SpecificationEvaluator<T>
    {
        public static SpecificationEvaluator<T> Instance { get; } = new SpecificationEvaluator<T>();
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

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (IEvaluator evaluator in _evaluators)
                query = evaluator.GetQuery(query, specification);
            return query;
        }
    }
}
