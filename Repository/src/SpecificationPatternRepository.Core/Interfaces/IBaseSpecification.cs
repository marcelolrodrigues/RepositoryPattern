using SpecificationPatternRepository.Core.Clauses;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public ICollection<WhereClause<T>> WhereClauses { get; }
        public ICollection<OrderByClause<T>> OrderByClauses { get; }
        public int? Skip { get; } // #question: porque aqui nao pode ser internal como está na implementação ?
        public int? Take { get; }
        public ICollection<IncludeClause> IncludeClauses { get; }
        public bool AsNoTracking { get; }
        public ICollection<LikeClause<T>> LikeClauses { get; }
    }

    public interface IBaseSpecification<T, TResult> : IBaseSpecification<T>
    {
        public SelectorClause<T, TResult> SelectClause { get; }
    }
}
