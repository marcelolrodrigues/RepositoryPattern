using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests
{
    public class RepositoryOfT_AnyAsync : IntegrationTestBase
    {
        public RepositoryOfT_AnyAsync(SharedDatabaseFixture sbf) : base(sbf) 
        {
            Console.WriteLine("addsasd");
        }

        [Fact]
        public async Task ReturnTrueOnStoresRecords_WithoutSpec()
        {
            List<Store> result = await StoreRepository.ListAsync();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
