using SpecificationPatternRepository.Core.Clauses;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<WhereClause<T>> WhereClauses { get; }
        public List<OrderByClause<T>> OrderByClauses { get; }
        public List<IncludeClause> IncludeClauses { get; }
        public int? Skip { get; }
        public int? Take { get; }
    }

    public interface IBaseSpecification<T, TResult> : IBaseSpecification<T>
    {
        public SelectorClause<T, TResult>? SelectorClause { get; }
    }
}
