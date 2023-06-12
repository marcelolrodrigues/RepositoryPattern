﻿using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Core.Evaluator
{
    public class InMemorySpecificationEvaluator : IInMemorySpecificationEvaluator
    {
        public static InMemorySpecificationEvaluator Instance { get; } = new InMemorySpecificationEvaluator();
        private List<IInMemoryEvaluatorOfT> _inMemoryEvaluators { get; }

        public InMemorySpecificationEvaluator()
        {
            _inMemoryEvaluators = new List<IInMemoryEvaluatorOfT>()
            {
                WhereClauseEvaluator.Instance,
                OrderByClauseEvaluator.Instance,
                PaginationEvaluator.Instance
            };
        }

        public IEnumerable<T> Evaluate<T>(IEnumerable<T> set, IBaseSpecification<T> specification)
        {
            foreach (IInMemoryEvaluatorOfT inMemoryEvaluator in _inMemoryEvaluators)
                set = inMemoryEvaluator.Evaluate(set, specification);
            return set;
        }

        public IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> set, IBaseSpecification<T, TResult> specification)
        {
            IEnumerable<T> partialset = new List<T>();
            foreach (IInMemoryEvaluatorOfT inMemoryEvaluator in _inMemoryEvaluators)
                partialset = inMemoryEvaluator.Evaluate<T>(set, specification);

            IEnumerable<TResult> resultset = 
                partialset.Select(specification.SelectorClause.Expression.Compile());

            return resultset;
        }
    }
}
