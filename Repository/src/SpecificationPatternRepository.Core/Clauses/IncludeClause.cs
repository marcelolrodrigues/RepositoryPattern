using SpecificationPatternRepository.Core.Types;
using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Clauses
{
    public class IncludeClause
    {
        public LambdaExpression Expression { get; }
        public Type EntityType { get; }
        public Type PropertyType { get; }
        public IncludeTypeEnum Type { get; }

        public IncludeClause(LambdaExpression expression, Type entityType, Type propertyType, IncludeTypeEnum type)
        {
            Expression = expression;
            EntityType = entityType;
            PropertyType = propertyType;
            Type = type;
        }
    }
}
