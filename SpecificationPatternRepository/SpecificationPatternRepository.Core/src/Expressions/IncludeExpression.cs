using System.Linq.Expressions;

namespace SpecificationPatternRepository.Core.Expressions
{
    public class IncludeExpression
    {
        public LambdaExpression LambdaExpression { get; set; }
        public Type EntityType { get; set; }
        public Type PropertyType { get; set; }
    }
}
