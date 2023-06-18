namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IEvaluator
    {
        IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification) where T : class;
    }
}
