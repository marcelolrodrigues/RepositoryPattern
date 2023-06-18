using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.Interfaces;
using SpecificationPatternRepository.Core.Types;
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
            WhereClause<T> clause = new WhereClause<T>(expression);
            BaseSpecification.WhereClauses.Add(clause);
            return this;
        }

        public IOrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> expression)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(expression, OrderByType.OrderBy)
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public IOrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            BaseSpecification.OrderByClauses.Add(
                new OrderByClause<T>(expression, OrderByType.OrderByDescending)
            );
            OrderedSpecificationBuilder<T> ordSpec = new OrderedSpecificationBuilder<T>(BaseSpecification);
            return ordSpec;
        }

        public ISpecificationBuilder<T> Skip(int skip)
        {
            if (BaseSpecification.Skip != null)
                throw new DuplicateSkipException();
            
            this.BaseSpecification.Skip = skip;
            return this;
        }

        public ISpecificationBuilder<T> Take(int take)
        {
            if (BaseSpecification.Take != null)
                throw new DuplicatedTakeException();
            this.BaseSpecification.Take = take;
            return this;
        }

        public ISpecificationBuilder<T> Include<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            IncludeClause clause = new IncludeClause(expression, typeof(T), typeof(TProperty), IncludeTypeEnum.Include);
            BaseSpecification.IncludeClauses.Add(clause);
            return (ISpecificationBuilder<T>)this;
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
            BaseSpecification.SelectClause = selector;
            return this;
        }

        public ISpecificationBuilder<T, TResult> SelectMany(Expression<Func<T, IEnumerable<TResult>>> expression)
        {
            SelectorClause<T, IEnumerable<TResult>> selector = new SelectorClause<T, IEnumerable<TResult>>(expression);
            BaseSpecification.SelectManyClause = selector;
            return this;
        }
    }
}
