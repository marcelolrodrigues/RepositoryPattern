using SpecificationPatternRepository.Core.Clauses;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public ICollection<WhereClause<T>> WhereClauses { get; }
        public ICollection<OrderByClause<T>> OrderByClauses { get; }
        public int? Skip { get; }
        public int? Take { get; }
        public ICollection<IncludeClause> IncludeClauses { get; }
    }

    public interface IBaseSpecification<T, TResult> : IBaseSpecification<T>
    {
        public SelectorClause<T, TResult>? SelectClause { get; }
    }
}
