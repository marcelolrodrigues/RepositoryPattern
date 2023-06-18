using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface ISpecificationBuilder<T>
    {
        BaseSpecification<T> BaseSpecification { get; }

        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> expression);
        public IOrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> expression);
        public IOrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> expression);
        public ISpecificationBuilder<T> Skip(int skip);
        public ISpecificationBuilder<T> Take(int take);
        public ISpecificationBuilder<T> Include<T, TProperty>(Expression<Func<T, TProperty>> expression);
        public ISpecificationBuilder<T> AsNoTracking(bool asNoTracking);
    }

    public interface ISpecificationBuilder<T, TResult> : ISpecificationBuilder<T>
    {
        new BaseSpecification<T, TResult> BaseSpecification { get; }

        public ISpecificationBuilder<T, TResult> Select(Expression<Func<T, TResult>> expression);
    }
}
