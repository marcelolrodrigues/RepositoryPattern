using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public interface IEvaluator
    {
        IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification) where T : class;
    }
}
