namespace Core.SpecificationPattern.Evaluator
{
    public interface ISpecificationEvaluator
    {
        IQueryable<T> GetQuery<T>(IQueryable<T> query, BaseSpecification<T> specification);
    }
}
