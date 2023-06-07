using Microsoft.EntityFrameworkCore;
using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace SpecificationPatternRepository.Infrastructure.Evaluators
{
    public class IncludeEvaluator : IEvaluator
    {
        public static IncludeEvaluator Instance { get; } = new IncludeEvaluator();

        public IQueryable<T> GetQuery<T>(IQueryable<T> query, IBaseSpecification<T> specification)
        {
            var IncludeMethodInfo = typeof(EntityFrameworkQueryableExtensions)
                .GetTypeInfo().GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include))
                .Single(
                    mi => mi.GetGenericArguments().Length == 2
                    && mi.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                    && mi.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>)
                );

            foreach (IncludeClause includeClause in specification.IncludeClauses)
            {
                var result = IncludeMethodInfo.MakeGenericMethod(
                    includeClause.EntityType,
                    includeClause.PropertyType
                ).Invoke(null, new object[] { query, includeClause.Expression });

                query = (IQueryable<T>)result;
            }

            return query;
        }
    }
}
