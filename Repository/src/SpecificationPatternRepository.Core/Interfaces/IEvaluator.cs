namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IEvaluator<T>
    {
        IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification);
    }
}
