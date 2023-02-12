﻿using Core.SpecificationPattern.Interfaces;
using Infrastructure.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

namespace SpecificationRepository.Infrastructure
{
    public class SpecificationRepository<T> : BaseRepository<T>, ISpecificationRepository<T> where T : class
    {
        private readonly DbContext _context;
        private SpecificationEvaluator<T> SpecificationEvaluator;

        public SpecificationRepository(DbContext context) : base(context)
        {
            this._context = context;
            SpecificationEvaluator = SpecificationEvaluator<T>.Instance;
        }

        public async Task<List<T>> ListWithSpecification(IBaseSpecification<T> specification)
        {
            IQueryable<T> query = GetQuery(specification);
            var list = await query.ToListAsync();
            return list;
        }

        private IQueryable<T> GetQuery(IBaseSpecification<T> specification)
        {
            IQueryable<T> query =  SpecificationEvaluator.GetQuery(
                _context.Set<T>().AsQueryable(), 
                specification
            );
            return query;
        }
    }
}
