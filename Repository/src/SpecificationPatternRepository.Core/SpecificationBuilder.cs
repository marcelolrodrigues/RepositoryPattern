using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class SpecificationBuilder<T> : ISpecificationBuilder<T>
    {
        private BaseSpecification<T> BaseSpecification { get; }

        public SpecificationBuilder(BaseSpecification<T> baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> expression)
        {
            BaseSpecification.WhereClauses.Add(new WhereClause<T>(expression));
            return this;
        }

        public OrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpressions,
                    OrderType = OrderByType.OrderBy
                }
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public OrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByExpressions.Add(
                new OrderExpression<T>()
                {
                    OrderByExpression = orderExpressions,
                    OrderType = OrderByType.OrderByDescending
                }
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public ISpecificationBuilder<T> Include(IncludeExpression includeExpressions)
        {
            BaseSpecification.IncludeExpressions.Add(includeExpressions);
            return this;
        }

        public ISpecificationBuilder<T> Skip(int skip)
        {
            if (BaseSpecification.Skip != null)
                throw new Exception("Duplicated Skip");
            this.BaseSpecification.Skip = skip;
            return this;
        }

        public ISpecificationBuilder<T> Take(int take)
        {
            if (BaseSpecification.Take != null)
                throw new Exception("Duplicated Take");
            this.BaseSpecification.Take = take;
            return this;
        }
    }
}
