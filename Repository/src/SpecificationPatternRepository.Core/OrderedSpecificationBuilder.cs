using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class OrderedSpecificationBuilder<T> : SpecificationBuilder<T>, IOrderedSpecificationBuilder<T>
    {
        private BaseSpecification<T> BaseSpecification { get; }

        public OrderedSpecificationBuilder(BaseSpecification<T> baseSpecification) : base (baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public OrderedSpecificationBuilder<T> ThenBy(Expression<Func<T, object>> orderExpression)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(orderExpression, OrderByType.ThenBy)
            );
            return this;
        }

        public OrderedSpecificationBuilder<T> ThenByDescending(Expression<Func<T, object>> orderExpression)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(orderExpression, OrderByType.ThenByDescending)
            );
            return this;
        }
    }
}
