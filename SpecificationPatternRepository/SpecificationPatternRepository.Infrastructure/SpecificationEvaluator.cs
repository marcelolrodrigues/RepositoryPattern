using SpecificationPatternRepository.Core.Interfaces;
using SpecificationPatternRepository.Infrastructure.Evaluators;

namespace SpecificationPatternRepository.Infrastructure
{
    public class SpecificationEvaluator<T>
    {
        public static SpecificationEvaluator<T> Instance { get; } = new SpecificationEvaluator<T>();
        private readonly List<IEvaluator<T>> Evaluators;

        public SpecificationEvaluator()
        {
            Evaluators = new List<IEvaluator<T>>()
            {
                WhereEvaluator<T>.Instance,
                OrderByEvaluator<T>.Instance,
                IncludeEvaluator<T>.Instance,
            };
        }

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            foreach (IEvaluator<T> evaluator in Evaluators)
                query = evaluator.GetQuery(query, specification);
            return query;
        }
    }
}
