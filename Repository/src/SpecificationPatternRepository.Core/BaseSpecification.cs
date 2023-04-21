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

        public SpecificationBuilder<T> SpecificationBuilder { get; }
        
        private InMemorySpecificationEvaluator InMemorySpecificationEvaluator { get; set; }

        public int? Skip { get; set; }
        public int? Take { get; set; }

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
}
