using SpecificationPatternRepository.Core.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<WhereClause<T>> WhereClauses { get; set; }
        public List<OrderExpression<T>> OrderByExpressions { get; set; }
        public List<IncludeExpression> IncludeExpressions { get; set; }
        public int? Skip { get; }
        public int? Take { get; }
    }

    public interface IBaseSpecification<T, TResult> : IBaseSpecification<T>
    {
        public List<SelectorClause<T, TResult>> SelectorClauses { get; set; }
    }
}
