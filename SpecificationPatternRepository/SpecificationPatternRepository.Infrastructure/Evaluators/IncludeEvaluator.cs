using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class IncludeEvaluator<T> : IEvaluator<T>
    {
        public static IncludeEvaluator<T> Instance { get; } = new IncludeEvaluator<T>();

        public IQueryable<T> GetQuery(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            var IncludeMethodInfo = typeof(EntityFrameworkQueryableExtensions)
                .GetTypeInfo().GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include))
                .Single(
                    mi => mi.GetGenericArguments().Length == 2
                    && mi.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                    && mi.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>)
                );

            foreach (IncludeExpression includeExpression in specification.IncludeExpressions)
            {
                var result = IncludeMethodInfo.MakeGenericMethod(
                    includeExpression.EntityType,
                    includeExpression.PropertyType
                ).Invoke(null, new object[] { query, includeExpression.LambdaExpression });

                query = (IQueryable<T>)result;
            }

            return query;
        }
    }
}
