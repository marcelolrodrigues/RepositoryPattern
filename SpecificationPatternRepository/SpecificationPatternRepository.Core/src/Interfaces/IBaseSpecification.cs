using SpecificationPatternRepository.Core.Expressions;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Interfaces
{
    public interface IBaseSpecification<T>
    {
        public List<WhereClause<T>> WhereClauses { get; }
        public List<OrderExpression<T>> OrderByExpressions { get; }
        public List<IncludeExpression> IncludeExpressions { get; }
    }
}
