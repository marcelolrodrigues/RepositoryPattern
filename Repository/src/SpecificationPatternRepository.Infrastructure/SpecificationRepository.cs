using BaseRepository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternRepository.Core.Interfaces;

namespace SpecificationPatternRepository.Infrastructure
{
    public class SpecificationRepository<T> : BaseRepository<T>, ISpecificationRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly SpecificationEvaluator _specificationEvaluator;

        public SpecificationRepository(DbContext context) : base(context)
        {
            _context = context;
            _specificationEvaluator = SpecificationEvaluator.Instance;
        }

        public async Task<List<T>> ListWithSpecification(IBaseSpecification<T> specification)
        {
            IQueryable<T> query = _specificationEvaluator.GetQuery(
                _context.Set<T>().AsQueryable(),
                specification
            ); 
            var list = await query.ToListAsync();
            return list;
        }
    }
}
