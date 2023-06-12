using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {       
        public List<WhereClause<T>> WhereClauses { get; set; }
        public List<OrderByClause<T>> OrderByClauses { get; set; }
        public List<IncludeClause> IncludeClauses { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        
        public ISpecificationBuilder<T> SpecificationBuilder { get; }
        private IInMemorySpecificationEvaluator _inMemorySpecificationEvaluator { get; set; }

        public BaseSpecification()
        {
            WhereClauses = new List<WhereClause<T>>();
            OrderByClauses = new List<OrderByClause<T>>();
            IncludeClauses = new List<IncludeClause>();
            SpecificationBuilder = new SpecificationBuilder<T>(this);
            _inMemorySpecificationEvaluator = InMemorySpecificationEvaluator.Instance;
        }

        public IEnumerable<T> EvaluateInMemory(IEnumerable<T> set)
        {
            IEnumerable<T> result = _inMemorySpecificationEvaluator.Evaluate(set, this);
            return result;
        }
    }

    public class BaseSpecification<T, TResult> : BaseSpecification<T>, IBaseSpecification<T, TResult>
    {
        public SelectorClause<T, TResult> SelectorClause { get; set; }

        public new SpecificationBuilder<T, TResult> SpecificationBuilder { get; }
        private IInMemorySpecificationEvaluator _inMemorySpecificationEvaluator { get; set; }

        public BaseSpecification()
        {
            SpecificationBuilder = new SpecificationBuilder<T, TResult>(this);
            _inMemorySpecificationEvaluator = InMemorySpecificationEvaluator.Instance;
        }

        public new IEnumerable<TResult> EvaluateInMemory(IEnumerable<T> set)
        {
            IEnumerable<TResult> result = _inMemorySpecificationEvaluator.Evaluate(set, this);
            return result;
        }
    }
}
