using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests
{
    public class InMemorySpecificationEvaluatorTests
    {
        [Fact]
        public void ReturnsStoreWithId10_GivenStoreByIdSpec()
        {
            StoreByIdSpec spec = new StoreByIdSpec(10);
            List<Store> stores = StoreSeed.Get();
            IEnumerable<Store> store = spec.Evaluate(stores, spec);
            store.FirstOrDefault().Id.Should().Be(10);
        }
    }
}