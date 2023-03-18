﻿using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class WhereClauseEvaluator : IInMemoryEvaluator
    {
        public static WhereClauseEvaluator Instance { get; } = new WhereClauseEvaluator();

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (WhereClause<T> clause in specification.WhereClauses)
                set = set.Where(clause.WhereFunc);
            return set;
        }
    }
}