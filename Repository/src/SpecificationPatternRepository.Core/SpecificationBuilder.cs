using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core
{
    public class SpecificationBuilder<T> : ISpecificationBuilder<T>
    {
        public BaseSpecification<T> BaseSpecification { get; }

        public SpecificationBuilder(BaseSpecification<T> baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> expression)
        {
            BaseSpecification.WhereClauses.Add(new WhereClause<T>(expression));
            return this;
        }

        public IOrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(orderExpressions, OrderByType.OrderBy)
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public IOrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpressions)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(orderExpressions, OrderByType.OrderByDescending)
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

    public class SpecificationBuilder<T, TResult> : SpecificationBuilder<T>, ISpecificationBuilder<T, TResult>
    {
        public new BaseSpecification<T, TResult> BaseSpecification { get; }

        public SpecificationBuilder(BaseSpecification<T, TResult> baseSpecification) : base(baseSpecification)
        {
            BaseSpecification = baseSpecification;
        }

        public ISpecificationBuilder<T, TResult> Select(Expression<Func<T, TResult>> expression)
        {
            SelectorClause<T, TResult> selector = new SelectorClause<T, TResult>(expression);
            BaseSpecification.SelectorClauses.Add(selector);
            return this;
        }
    }
}
