using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class IntegrationTestBase : IClassFixture<SharedDatabaseFixture>
    {
        protected RepositoryOfT<Store> StoreRepository;
        protected RepositoryOfT<Address> AddressRepository;

        public IntegrationTestBase(SharedDatabaseFixture fixture)
        {
            TestDbContext context = fixture.CreateContext();
            StoreRepository = new RepositoryOfT<Store>(context);
            AddressRepository = new RepositoryOfT<Address>(context);
        }
    }
}
