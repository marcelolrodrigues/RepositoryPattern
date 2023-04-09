using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Interfaces;
using SpecificationPatternRepository.Infrastructure.Evaluators;

namespace SpecificationPatternRepository.Infrastructure
{
    public class SpecificationEvaluator<T>
    {
        public static SpecificationEvaluator<T> Instance { get; } = new SpecificationEvaluator<T>();
        private readonly List<IEvaluator> Evaluators;

        public SpecificationEvaluator()
        {
            Evaluators = new List<IEvaluator>()
            {
                WhereClauseEvaluator.Instance,
                OrderByEvaluator.Instance,
                IncludeEvaluator.Instance,
            };
        }

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (IEvaluator evaluator in Evaluators)
                query = evaluator.GetQuery(query, specification);
            return query;
        }
    }
}
