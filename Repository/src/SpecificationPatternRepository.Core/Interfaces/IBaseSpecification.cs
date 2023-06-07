using SpecificationPatternRepository.Core.Clauses;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<WhereClause<T>> WhereClauses { get; set; }
        public List<OrderByClause<T>> OrderByClauses { get; set; }
        public List<IncludeClause> IncludeClauses { get; set; }
        public int? Skip { get; }
        public int? Take { get; }
    }

    public interface IBaseSpecification<T, TResult> : IBaseSpecification<T>
    {
        public List<SelectorClause<T, TResult>> SelectorClauses { get; set; }
    }
}
