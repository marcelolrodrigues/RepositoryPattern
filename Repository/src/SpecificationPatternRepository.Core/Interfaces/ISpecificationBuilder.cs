using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface ISpecificationBuilder<T>
    {
        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> expression);
        public OrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpressions);
        public OrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpressions);
        public ISpecificationBuilder<T> Include(IncludeExpression includeExpressions);
        public ISpecificationBuilder<T> Skip(int skip);
        public ISpecificationBuilder<T> Take(int take);
    }
}
