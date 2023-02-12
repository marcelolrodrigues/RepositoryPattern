using SpecificationRepository.Infrastructure.Evaluators;
using Core.SpecificationPattern.Interfaces;

namespace SpecificationRepository.Infrastructure
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
                OrderByEvaluator<T>.Instance
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
