namespace Core.SpecificationPattern.Evaluator
{
    public interface IEvaluator
    {
        IQueryable<T> GetQuery<T>(IQueryable<T> query, BaseSpecification<T> specification);
    }
}
