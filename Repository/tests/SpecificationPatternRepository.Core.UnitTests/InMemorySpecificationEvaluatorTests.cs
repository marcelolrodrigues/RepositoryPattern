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
            
            Store store = spec.Evaluate(stores, spec).FirstOrDefault();
            
            store?.Id.Should().Be(10);
        }

        [Fact]
        public void ReturnsStoreWithIdFrom15To30_GivenStoresByIdListSpec()
        {
            IEnumerable<int> ids = Enumerable.Range(15, 16);
            StoreByIdListSpec spec = new StoreByIdListSpec(ids);
            
            IEnumerable<Store> stores = spec.Evaluate(StoreSeed.Get(), spec);
            
            stores.Count().Should().Be(16);
            stores.OrderBy(x => x.Id).First().Id.Equals(15);
            stores.OrderBy(x => x.Id).Last().Id.Should().Be(30);
        }
    }
}