
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class IntegrationTestBase : IClassFixture<SharedDatabaseFixture>
    {
        public TestDbContext context { get; set; }
        protected RepositoryOfT<Store> StoreRepository;
        protected RepositoryOfT<Address> AddressRepository;

        public IntegrationTestBase(SharedDatabaseFixture fixture)
        {
            context = fixture.CreateContext();
            StoreRepository = new RepositoryOfT<Store>(context);
            AddressRepository = new RepositoryOfT<Address>(context);
        }
    }
}
