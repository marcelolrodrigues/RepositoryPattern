using BaseRepository.Infrastructure;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class RepositoryOfT<T> : BaseRepository<T> where T : class
    {
        protected readonly TestDbContext dbContext;

        public RepositoryOfT(TestDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
