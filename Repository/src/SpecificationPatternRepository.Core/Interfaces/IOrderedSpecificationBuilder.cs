using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IOrderedSpecificationBuilder<T> : ISpecificationBuilder<T>
    {
        public OrderedSpecificationBuilder<T> ThenBy(Expression<Func<T, object>> orderExpression);
        public OrderedSpecificationBuilder<T> ThenByDescending(Expression<Func<T, object>> orderExpression);
    }
}
