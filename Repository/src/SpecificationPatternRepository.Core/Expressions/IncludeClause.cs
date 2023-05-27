using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class IncludeClause
    {
        public LambdaExpression Expression { get; set; }
        public Type EntityType { get; set; }
        public Type PropertyType { get; set; }
    }
}
