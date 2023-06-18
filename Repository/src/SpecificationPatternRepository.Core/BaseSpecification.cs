using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Evaluator;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {       
        public ICollection<WhereClause<T>> WhereClauses { get; }
        public ICollection<OrderByClause<T>> OrderByClauses { get; }
        public int? Skip { get; internal set; }
        public int? Take { get; internal set; }
        public ICollection<IncludeClause> IncludeClauses { get; }
        public bool AsNoTracking { get; internal set; }

        public ISpecificationBuilder<T> SpecificationBuilder { get; }
        
        protected IInMemorySpecificationEvaluator _inMemorySpecificationEvaluator { get; }

        public BaseSpecification()
        {
            WhereClauses = new List<WhereClause<T>>();
            OrderByClauses = new List<OrderByClause<T>>();
            Skip = null;
            Take = null;
            IncludeClauses = new List<IncludeClause>();
            AsNoTracking = false;
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
        public SelectorClause<T, TResult>? SelectClause { get; internal set; }
        public SelectorClause<T, IEnumerable<TResult>>? SelectManyClause { get; internal set; }

        public new SpecificationBuilder<T, TResult> SpecificationBuilder { get; }

        public BaseSpecification()
        {
            SelectClause = null;
            SelectManyClause = null;
            SpecificationBuilder = new SpecificationBuilder<T, TResult>(this);
        }

        public new IEnumerable<TResult> EvaluateInMemory(IEnumerable<T> set)
        {
            IEnumerable<TResult> result = _inMemorySpecificationEvaluator.Evaluate(set, this);
            return result;
        }
    }
}
