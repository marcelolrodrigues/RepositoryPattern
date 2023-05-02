using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface ISpecificationBuilder<T>
    {
        BaseSpecification<T> BaseSpecification { get; }

        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> expression);
        public IOrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpressions);
        public IOrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpressions);
        public ISpecificationBuilder<T> Include(IncludeExpression includeExpressions);
        public ISpecificationBuilder<T> Skip(int skip);
        public ISpecificationBuilder<T> Take(int take);
    }

    public interface ISpecificationBuilder<T, TResult> : ISpecificationBuilder<T>
    {
        new BaseSpecification<T, TResult> BaseSpecification { get; }

        public ISpecificationBuilder<T, TResult> Select(Expression<Func<T, TResult>> expression);
    }
}
