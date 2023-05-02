using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public List<WhereClause<T>> WhereClauses { get; set; }
        public List<OrderExpression<T>> OrderByExpressions { get; set; }
        public List<IncludeExpression> IncludeExpressions { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public ISpecificationBuilder<T> SpecificationBuilder { get; }
        private InMemorySpecificationEvaluator InMemorySpecificationEvaluator { get; set; }

        public BaseSpecification()
        {
            WhereClauses = new List<WhereClause<T>>();
            OrderByExpressions = new List<OrderExpression<T>>();
            IncludeExpressions = new List<IncludeExpression>();
            SpecificationBuilder = new SpecificationBuilder<T>(this);
            InMemorySpecificationEvaluator = new InMemorySpecificationEvaluator();
        }

        public IEnumerable<T> Evaluate(IEnumerable<T> set)
        {
            IEnumerable<T> result = InMemorySpecificationEvaluator.Evaluate(set, this);
            return result;
        }
    }

    public class BaseSpecification<T, TResult> : BaseSpecification<T>, IBaseSpecification<T, TResult>
    {
        public List<SelectorClause<T, TResult>> SelectorClauses { get; set; }

        public new SpecificationBuilder<T, TResult> SpecificationBuilder { get; }
        private InMemorySpecificationEvaluator InMemorySpecificationEvaluator { get; set; }


        public BaseSpecification()
        {
            SelectorClauses = new List<SelectorClause<T, TResult>>();
            SpecificationBuilder = new SpecificationBuilder<T, TResult>(this);
            InMemorySpecificationEvaluator = new InMemorySpecificationEvaluator();
        }

        public new IEnumerable<TResult> Evaluate(IEnumerable<T> set)
        {
            IEnumerable<TResult> result = InMemorySpecificationEvaluator.Evaluate(set, this);
            return result;
        }
    }
}
