using Core.SpecificationPattern;
using Core.SpecificationPattern.Evaluator;
using Infrastructure.RepositoryPattern.Evaluators;

namespace Infrastructure.RepositoryPattern
{
    public class SpecificationEvaluator : ISpecificationEvaluator
    {
        public static SpecificationEvaluator Instance { get; } = new SpecificationEvaluator();
        private readonly List<IEvaluator> Evaluators;

        public SpecificationEvaluator()
        {
            Evaluators = new List<IEvaluator>()
            {
                WhereEvaluator.Instance,
                OrderByEvaluator.Instance
            };
        }

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, BaseSpecification<T> specification)
        {
            foreach (IEvaluator evaluator in Evaluators)
            {
                query = evaluator.GetQuery(query, specification);
            }
            return query;
        }
    }
}
